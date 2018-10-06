using System;
using System.IO;
using System.Text;
using DPA_Musicsheets.Adapters;
using DPA_Musicsheets.Enums;
using DPA_Musicsheets.Models;
using DPA_Musicsheets.MusicLoaders;
using Microsoft.Win32;

namespace DPA_Musicsheets.Managers
{
    public class FileManager
    {
        public AbstractMusicLoader GetMusicLoader()
        {
            var musicLoaderFactory = new MusicLoaderFactory();
            var openFileDialog = new OpenFileDialog
            {
                Filter = musicLoaderFactory.GetExtensionFilter()
            };

            if (openFileDialog.ShowDialog() != true) return null;
            var extension = Path.GetExtension(openFileDialog.FileName);
            var musicLoader = musicLoaderFactory.GetMusicLoader(extension);

            if (musicLoader == null) return null;
            musicLoader.FilePath = openFileDialog.FileName;
            return musicLoader;
        }

        public string OpenFile()
        {
            var openFileDialog = new OpenFileDialog() { Filter = "Midi or LilyPond files (*.mid *.ly)|*.mid;*.ly" };
            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : null;
        }

        public string LoadFile(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            var fileExtension = fileInfo.Extension.ToUpper();
            if (string.IsNullOrEmpty(fileExtension) || !Enum.TryParse(fileExtension, out FileExtension result)) return null;
            switch (result)
            {
                case FileExtension.MID:
                    return LoadMidi(filePath);
                case FileExtension.LY:
                    return LoadLilypond(filePath);
                default:
                    throw new NotSupportedException($"File extension {fileExtension} is not supported.");
            }
        }

        private string LoadLilypond(string filePath)
        {
            var stringBuilder = new StringBuilder();
            foreach (var line in File.ReadAllLines(filePath))
            {
                stringBuilder.AppendLine(line);
            }

            return stringBuilder.ToString();
        }

        private string LoadMidi(string filePath)
        {
            var midiSequence = new MidiSequence();
            midiSequence.Load(filePath);
            return "Midi";
        }

        public string WriteFile(Piece piece, string filter)
        {
            throw new NotImplementedException();
        }
    }
}