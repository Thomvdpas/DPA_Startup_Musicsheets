using DPA_Musicsheets.Facades;
using Sanford.Multimedia.Midi;

namespace DPA_Musicsheets.Adapters
{
    public class MidiSequencer
    {
        private readonly Sequencer _internalSequencer;
        private MidiSequence _internalMidiSequence;

        public int Position
        {
            get => _internalSequencer.Position;
            set => _internalSequencer.Position = value;
        }

        public MidiSequencer()
        {
            _internalSequencer = new Sequencer();
            _internalMidiSequence = new MidiSequence(_internalSequencer.Sequence);
        }

        public MidiSequencer(Sequencer sequencer)
        {
            _internalSequencer = sequencer;
        }

        public Sequencer GetSequencer()
        {
            return _internalSequencer;
        }

        public void Continue()
        {
            _internalSequencer.Continue();
        }

        public void Stop()
        {
            _internalSequencer.Stop();
        }

        public void Dispose()
        {
            _internalSequencer.Dispose();
        }

        public MidiSequence GetSequence()
        {
            return _internalMidiSequence;
        }

        public void SetSequence(MidiSequence sequence)
        {
            _internalMidiSequence = sequence;
        }
    }
}
