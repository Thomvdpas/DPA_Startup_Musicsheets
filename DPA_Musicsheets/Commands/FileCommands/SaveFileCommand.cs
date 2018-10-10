using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DPA_Musicsheets.Command;
using DPA_Musicsheets.Managers;
using DPA_Musicsheets.MusicLoaders;

namespace DPA_Musicsheets.Commands.FileCommands
{
    public class SaveFileCommand : FileHandlingCommand
    {
        private readonly string _filter;

        public SaveFileCommand(string filter)
        {
            _filter = filter;
        }

        public override void Execute()
        {
            if (Piece == null) return;

            var lilypondMusicLoader = new LilypondMusicLoader();

            //lilypondMusicLoader.IsFixingBars = true;

            var piece = lilypondMusicLoader.LoadLilypondText(LilypondText);
            var fileManager = new FileManager();
            var message = fileManager.WriteFile(piece, _filter);

            if (message != null)
            {
                MessageBox.Show(message);
            }

            //EventBus.Fire(new PieceSavedEvent());
        }
    }
}
