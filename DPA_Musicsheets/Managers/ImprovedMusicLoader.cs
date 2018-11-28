using DPA_Musicsheets.Models;
using DPA_Musicsheets.Enums;
using DPA_Musicsheets.ViewModels;
using PSAMControlLibrary;
using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DPA_Musicsheets.Adapters;

namespace DPA_Musicsheets.Managers
{
    /// <summary>
    /// This is the one and only god class in the application.
    /// It knows all about all file types, knows every viewmodel and contains all logic.
    /// TODO: Clean this class up.
    /// </summary>
    public class ImprovedMusicLoader
    {
        public event EventHandler<MidiSequencer> MidiLoaded;
        public event EventHandler<MidiSequencer> StaffsLoaded;
        public event EventHandler<string> LilypondLoaded;

        #region Properties
        public string LilypondText { get; set; }
        public List<MusicalSymbol> WPFStaffs { get; set; } = new List<MusicalSymbol>();
        private static List<Char> notesorder = new List<Char> { 'c', 'd', 'e', 'f', 'g', 'a', 'b' };

        public MidiSequence MidiSequence { get; set; }
        #endregion Properties

        private int _beatNote = 4;    // De waarde van een beatnote.
        private int _bpm = 120;       // Aantal beatnotes per minute.
        private int _beatsPerBar;     // Aantal beatnotes per maat.

        //public MainViewModel MainViewModel { get; set; }
        //public LilypondViewModel LilypondViewModel { get; set; }
        //public MidiPlayerViewModel MidiPlayerViewModel { get; set; }
        //public StaffsViewModel StaffsViewModel { get; set; }

        /// <summary>
        /// Opens a file.
        /// TODO: Remove the switch cases and delegate.
        /// TODO: Remove the knowledge of filetypes. What if we want to support MusicXML later?
        /// TODO: Remove the calling of the outer viewmodel layer. We want to be able reuse this in an ASP.NET Core application for example.
        /// </summary>
        /// <param name="fileName"></param>
        public void OpenFile(string fileName)
        {
            var fileManager = new FileManager();
            var result = fileManager.LoadFile(fileName);
            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);
            }
            else
            {
                throw new NotSupportedException($"File extension {Path.GetExtension(fileName)} is not supported.");
            }

            //if (Path.GetExtension(fileName).EndsWith(".mid"))
            //{
            //    MidiSequence = new MidiSequence();
            //    MidiSequence.Load(fileName);

            //    MidiPlayerViewModel.MidiSequence = MidiSequence.GetSequence();
            //    this.LilypondText = LoadMidiIntoLilypond(MidiSequence);
            //    this.LilypondViewModel.LilypondTextLoaded(this.LilypondText);
            //}
            //else if (Path.GetExtension(fileName).EndsWith(".ly"))
            //{
            //    StringBuilder sb = new StringBuilder();
            //    foreach (var line in File.ReadAllLines(fileName))
            //    {
            //        sb.AppendLine(line);
            //    }

            //    this.LilypondText = sb.ToString();
            //    this.LilypondViewModel.LilypondTextLoaded(this.LilypondText);
            //}
            //else
            //{
            //    throw new NotSupportedException($"File extension {Path.GetExtension(fileName)} is not supported.");
            //}
        }

      

        #region Saving to files
        internal void SaveToMidi(string fileName)
        {
            MidiSequence midiSequence = GetSequenceFromWPFStaffs();

            midiSequence.Save(fileName);
        }

        /// <summary>
        /// We create MIDI from WPF staffs, 2 different dependencies, not a good practice.
        /// TODO: Create MIDI from our own domain classes.
        /// TODO: Our code doesn't support repeats (rendering notes multiple times) in midi yet. Maybe with a COMPOSITE this will be easier?
        /// </summary>
        /// <returns></returns>
        private MidiSequence GetSequenceFromWPFStaffs()
        {
            List<string> notesOrderWithCrosses = new List<string>() { "c", "cis", "d", "dis", "e", "f", "fis", "g", "gis", "a", "ais", "b" };
            int absoluteTicks = 0;

            MidiSequence midiSequence = new MidiSequence();

            MidiTrack metaTrack = new MidiTrack();
            midiSequence.Add(metaTrack);

            // Calculate tempo
            int speed = (60000000 / _bpm);
            byte[] tempo = new byte[3];
            tempo[0] = (byte)((speed >> 16) & 0xff);
            tempo[1] = (byte)((speed >> 8) & 0xff);
            tempo[2] = (byte)(speed & 0xff);
            metaTrack.Insert(0 /* Insert at 0 ticks*/, new MetaMessage(MetaType.Tempo, tempo));

            MidiTrack notesTrack = new MidiTrack();
            midiSequence.Add(notesTrack);

            for (int i = 0; i < WPFStaffs.Count; i++)
            {
                var musicalSymbol = WPFStaffs[i];
                switch (musicalSymbol.Type)
                {
                    case MusicalSymbolType.Note:
                        Note note = musicalSymbol as Note;

                        // Calculate duration
                        double absoluteLength = 1.0 / (double)note.Duration;
                        absoluteLength += (absoluteLength / 2.0) * note.NumberOfDots;

                        double relationToQuartNote = _beatNote / 4.0;
                        double percentageOfBeatNote = (1.0 / _beatNote) / absoluteLength;
                        double deltaTicks = (midiSequence.Division / relationToQuartNote) / percentageOfBeatNote;

                        // Calculate height
                        int noteHeight = notesOrderWithCrosses.IndexOf(note.Step.ToLower()) + ((note.Octave + 1) * 12);
                        noteHeight += note.Alter;
                        notesTrack.Insert(absoluteTicks, new ChannelMessage(ChannelCommand.NoteOn, 1, noteHeight, 90)); // Data2 = volume

                        absoluteTicks += (int)deltaTicks;
                        notesTrack.Insert(absoluteTicks, new ChannelMessage(ChannelCommand.NoteOn, 1, noteHeight, 0)); // Data2 = volume

                        break;
                    case MusicalSymbolType.TimeSignature:
                        byte[] timeSignature = new byte[4];
                        timeSignature[0] = (byte)_beatsPerBar;
                        timeSignature[1] = (byte)(Math.Log(_beatNote) / Math.Log(2));
                        metaTrack.Insert(absoluteTicks, new MetaMessage(MetaType.TimeSignature, timeSignature));
                        break;
                    default:
                        break;
                }
            }

            notesTrack.Insert(absoluteTicks, MetaMessage.EndOfTrackMessage);
            metaTrack.Insert(absoluteTicks, MetaMessage.EndOfTrackMessage);
            return midiSequence;
        }

        internal void SaveToPDF(string fileName)
        {
            string withoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string tmpFileName = $"{fileName}-tmp.ly";
            SaveToLilypond(tmpFileName);

            string lilypondLocation = @"C:\Program Files (x86)\LilyPond\usr\bin\lilypond.exe";
            string sourceFolder = Path.GetDirectoryName(tmpFileName);
            string sourceFileName = Path.GetFileNameWithoutExtension(tmpFileName);
            string targetFolder = Path.GetDirectoryName(fileName);
            string targetFileName = Path.GetFileNameWithoutExtension(fileName);

            var process = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = sourceFolder,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = String.Format("--pdf \"{0}\\{1}.ly\"", sourceFolder, sourceFileName),
                    FileName = lilypondLocation
                }
            };

            process.Start();
            while (!process.HasExited)
            { /* Wait for exit */
            }
            if (sourceFolder != targetFolder || sourceFileName != targetFileName)
            {
                File.Move(sourceFolder + "\\" + sourceFileName + ".pdf", targetFolder + "\\" + targetFileName + ".pdf");
                File.Delete(tmpFileName);
            }
        }

        internal void SaveToLilypond(string fileName)
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.Write(LilypondText);
                outputFile.Close();
            }
        }
        #endregion Saving to files

        protected virtual void OnMidiLoaded(MidiSequencer e)
        {
            MidiLoaded?.Invoke(this, e);
        }
    }
}
