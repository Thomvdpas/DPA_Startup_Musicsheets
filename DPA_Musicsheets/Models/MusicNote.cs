using DPA_Musicsheets.Enums;

namespace DPA_Musicsheets.Models
{
    public class MusicNote : BaseNote
    {
        public MusicNote(NoteType noteType, double duration, PitchType pitchType) : base(pitchType, noteType, duration)
        {
            
        }

        public override BaseNote Clone()
        {
            return new MusicNote(NoteType, Duration, PitchType);
        }
    }
}