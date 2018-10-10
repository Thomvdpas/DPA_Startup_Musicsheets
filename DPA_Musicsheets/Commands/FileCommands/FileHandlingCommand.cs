using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.MusicLoaders;

namespace DPA_Musicsheets.Command
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
