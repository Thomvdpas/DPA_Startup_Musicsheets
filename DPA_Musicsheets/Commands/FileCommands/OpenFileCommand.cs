using DPA_Musicsheets.Managers;

namespace DPA_Musicsheets.Commands.FileCommands
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
