using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.MusicLoaders;

namespace DPA_Musicsheets.Command
{
    public class LoadFileCommand : FileHandlingCommand
    {

        public override void Execute()
        {
            if (MusicLoader == null) return;

            if (MusicLoader is LilypondMusicLoader lilypondMusicLoader)
            {
                //lilypondMusicLoader.IsFixingBars = true;
                Piece = lilypondMusicLoader.Load();
            }
            else
            {
                Piece = MusicLoader.Load();
            }

            //EventBus.Fire(new PieceLoadedEvent(Piece));
        }
    }
}
