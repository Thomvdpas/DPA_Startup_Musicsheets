using DPA_Musicsheets.Models;

namespace DPA_Musicsheets.MusicLoaders
{
    public abstract class AbstractMusicLoader
    {
        public string FilterName { get; set; }
        public string Extension { get; set; }
        public string Filter => $"{FilterName}|*{Extension}";
        public string FilePath { get; set; }
        public abstract Piece Load();
    }
}