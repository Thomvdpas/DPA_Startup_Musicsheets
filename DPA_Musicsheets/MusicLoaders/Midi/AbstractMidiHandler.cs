using DPA_Musicsheets.Models;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.MusicLoaders.Midi
{
    public abstract class AbstractMidiHandler
    {
        public MessageType MessageType { get; set; }
        public MidiStrategy MidiStrategy { get; set; }

        public abstract void Handle(MidiEvent midiEvent, MusicPiece piece);
    }
}