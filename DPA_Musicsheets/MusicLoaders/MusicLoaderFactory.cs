using System.Collections.Generic;
using System.Linq;

namespace DPA_Musicsheets.MusicLoaders
{
    public class MusicLoaderFactory
    {
        public readonly List<AbstractMusicLoader> MusicLoaders;

        public MusicLoaderFactory()
        {
            MusicLoaders = new List<AbstractMusicLoader>
            {
                new MidiMusicLoader(),
                new LilypondMusicLoader()
            };
        }

        public string GetExtensionFilter()
        {
            return string.Join("|", MusicLoaders.Select(t => t.Filter).ToArray());
        }

        public AbstractMusicLoader GetMusicLoader(string extension)
        {
            return MusicLoaders.FirstOrDefault(l => l.Extension.Equals(extension));
        }
    }
}