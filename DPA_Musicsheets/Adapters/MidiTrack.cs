using Sanford.Multimedia.Midi;
using System.Collections.Generic;

namespace DPA_Musicsheets.Adapters
{
    public class MidiTrack
    {
        private Track _internalTrack;

        public MidiTrack()
        {
            _internalTrack = new Track();
        }

        public MidiTrack(Track track)
        {
            _internalTrack = track;
        }

        public IEnumerable<MidiEvent> GetEvents()
        {
            return _internalTrack.Iterator();
        }

        public Track GetTrack()
        {
            return _internalTrack;
        }

        public void Insert(int position, IMidiMessage iMidiMessage)
        {
            _internalTrack.Insert(position, iMidiMessage);
        }
    }
}
