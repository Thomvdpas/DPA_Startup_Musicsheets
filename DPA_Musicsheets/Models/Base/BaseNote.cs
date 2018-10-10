using DPA_Musicsheets.Enums;
using DPA_Musicsheets.Interfaces;

namespace DPA_Musicsheets.Models.Base
{
    public abstract class BaseNote : ICloneable<BaseNote>
    {
        public NoteType NoteType;
        public PitchType PitchType;
        public DurationType DurationType;

        public int Octaves;
        public int Dots;
        public bool IsTied;

        public abstract BaseNote ShallowClone();

        public abstract BaseNote Clone();
    }
}
