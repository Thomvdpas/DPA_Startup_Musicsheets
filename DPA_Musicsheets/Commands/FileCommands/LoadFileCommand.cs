using DPA_Musicsheets.MusicLoaders;

namespace DPA_Musicsheets.Commands.FileCommands
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
