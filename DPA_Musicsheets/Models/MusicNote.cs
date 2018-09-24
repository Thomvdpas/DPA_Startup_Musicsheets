using DPA_Musicsheets.Enums;

namespace DPA_Musicsheets.Models
{
    public class MusicNote : BaseNote
    {
        public MusicNote(PitchType pitchType, NoteType noteType, double duration) : base(pitchType, noteType, duration)
        {
            
        }

        public override BaseNote ShallowClone()
        {
            return (MusicNote) MemberwiseClone();
        }

        public override BaseNote Clone()
        {
            return new MusicNote(PitchType, NoteType, Duration);
        }
    }
}