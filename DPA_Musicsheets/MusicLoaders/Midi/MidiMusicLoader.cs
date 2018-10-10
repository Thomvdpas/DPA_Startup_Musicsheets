using DPA_Musicsheets.Models;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.MusicLoaders.Midi
{
    public class MidiMusicLoader : AbstractMusicLoader
    {
        private readonly MidiHandlerFactory _midiHandlerFactory;

        public MidiMusicLoader()
        {
            _midiHandlerFactory = new MidiHandlerFactory();
            FilterName = "Midi";
            Extension = ".mid";
        }

        public override MusicPiece Load()
        {
            var midiSequence = new Sequence(FilePath);
            return ConvertToPiece(midiSequence);
        }

        private MusicPiece ConvertToPiece(Sequence sequence)
        {
            var newPiece = new MusicPiece(sequence.Division);
            foreach (var track in sequence)
            {
                foreach (var midiEvent in track.Iterator())
                {
                    var messageType = midiEvent.MidiMessage.MessageType;
                    var midiHandler = _midiHandlerFactory.GetMidiHandler(messageType);
                    midiHandler.Handle(midiEvent, newPiece);
                }
            }

            return newPiece;
        }
    }
}