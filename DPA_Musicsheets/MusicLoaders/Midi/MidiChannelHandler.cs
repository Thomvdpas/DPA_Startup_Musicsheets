using DPA_Musicsheets.Models;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.MusicLoaders.Midi
{
    public class MidiChannelHandler : AbstractMidiHandler
    {
        public MidiChannelHandler()
        {
            MessageType = MessageType.Channel;
        }

        public override void Handle(MidiEvent midiEvent, MusicPiece piece)
        {
            throw new System.NotImplementedException();
        }
    }
}