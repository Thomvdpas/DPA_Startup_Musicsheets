using DPA_Musicsheets.Enums;
using DPA_Musicsheets.Interfaces;

namespace DPA_Musicsheets.Models
{
    public abstract class BaseNote : ICloneable<BaseNote>
    {
        private double _duration;

        public PitchType PitchType;
        protected NoteType NoteType;
        public bool IsPoint;

        public double Duration
        {
            get => IsPoint ? _duration * 1.5 : _duration;
            set => _duration = value;
        }

        protected BaseNote()
        {

        }

        protected BaseNote(NoteType noteType)
        {
            NoteType = noteType;
        }

        protected BaseNote(PitchType pitchType, NoteType noteType, double duration)
        {
            PitchType = pitchType;
            NoteType = noteType;
            Duration = duration;
        }

        public abstract BaseNote ShallowClone();

        public abstract BaseNote Clone();
    }
}
