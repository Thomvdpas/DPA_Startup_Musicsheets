using DPA_Musicsheets.Enums;
using DPA_Musicsheets.Models.Base;

namespace DPA_Musicsheets.Models
{
    public class MusicNote : BaseNote
    {
        public MusicNote()
        {
            PitchType = PitchType.None;
        }

        public override BaseNote ShallowClone()
        {
            return (MusicNote) MemberwiseClone();
        }

        public override BaseNote Clone()
        {
            return new MusicNote();
        }
    }
}