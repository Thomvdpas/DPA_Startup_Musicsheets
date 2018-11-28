using DPA_Musicsheets.Models;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.MusicLoaders.Midi
{
    public class MidiMusicLoader : AbstractMusicLoader
    {
        public MidiMusicLoader()
        {
            FilterName = "Midi";
            Extension = ".mid";
        }

        public override MusicPiece Load()
        {
            var midiSequence = new Sequence(FilePath);
            var midiStrategy = new MidiStrategy(midiSequence);

            return midiStrategy.Convert();
        }
    }
}