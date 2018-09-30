using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.Adapters
{
    public class MidiSequence
    {
        private Sequence InternalSequence { get; set; }
        public int Division => InternalSequence.Division;
        public int Count => InternalSequence.Count;

        public MidiSequence()
        {
            InternalSequence = new Sequence();
        }

        public MidiSequence(Sequence sequence)
        {
            InternalSequence = sequence;
        }

        public Sequence GetSequence()
        {
            return InternalSequence;
        }

        public MidiTrack GetTrack(int number)
        {
            return new MidiTrack(InternalSequence[number]);
        }

        internal void Load(string fileName)
        {
            InternalSequence.Load(fileName);
        }

        public void Save(string fileName)
        {
            InternalSequence.Save(fileName);
        }

        public void Add(MidiTrack midiTrack)
        {
            InternalSequence.Add(midiTrack.GetTrack());
        }

    }
}
