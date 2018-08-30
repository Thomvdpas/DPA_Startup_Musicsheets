using DPA_Musicsheets.Enums;

namespace DPA_Musicsheets.Models
{
    public class MusicNote : BaseNote
    {
        public MusicNote(NoteType noteType, Duration duration) : base(noteType, duration)
        {
            NoteType = noteType;
            Duration = duration;
        }
    }
}