using System;
using System.IO;
using System.Text;
using DPA_Musicsheets.Enums;
using DPA_Musicsheets.Facades;
using DPA_Musicsheets.ViewModels;

namespace DPA_Musicsheets.Managers
{
    public class FileManager
    {
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
    }
}