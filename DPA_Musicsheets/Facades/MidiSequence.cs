using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Adapters;

namespace DPA_Musicsheets.Facades
{
    public class MidiSequence
    {

        private Sequence _internalSequence { get; set; }
        public int Division => _internalSequence.Division;
        public int Count => _internalSequence.Count;

        public MidiSequence()
        {
            this._internalSequence = new Sequence();
        }

        public Sequence GetSequence()
        {
            return _internalSequence;
        }

        public MidiTrack GetTrack(int number)
        {
            return new MidiTrack(_internalSequence[number]);
        }

        internal void Load(string fileName)
        {
            _internalSequence.Load(fileName);
        }

        public void Save(string fileName)
        {
            _internalSequence.Save(fileName);
        }

        public void Add(MidiTrack midiTrack)
        {
            _internalSequence.Add(midiTrack.GetTrack());
        }

    }
}
