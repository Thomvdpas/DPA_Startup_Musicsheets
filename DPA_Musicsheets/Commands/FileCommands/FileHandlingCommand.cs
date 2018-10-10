using System;
using DPA_Musicsheets.MusicLoaders;

namespace DPA_Musicsheets.Commands.FileCommands
{
    public class FileHandlingCommand : AbstractCommand
    {
        public static AbstractMusicLoader MusicLoader { get; set; }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
