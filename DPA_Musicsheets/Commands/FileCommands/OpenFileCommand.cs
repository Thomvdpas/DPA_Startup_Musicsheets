using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Managers;

namespace DPA_Musicsheets.Command
{
    public class OpenFileCommand : FileHandlingCommand
    {

        public override void Execute()
        {
            var fileManager = new FileManager();
            MusicLoader = fileManager.GetMusicLoader();
        }
    }
}
