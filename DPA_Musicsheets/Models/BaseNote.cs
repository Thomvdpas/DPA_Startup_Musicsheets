using DPA_Musicsheets.Enums;
using Duration = DPA_Musicsheets.Enums.Duration;

namespace DPA_Musicsheets.Models
{
    public abstract class BaseNote
    {
        protected NoteType NoteType;
        protected Duration Duration;

        protected BaseNote(NoteType noteType, Duration duration)
        {
            NoteType = noteType;
            Duration = duration;
        }
    }
}
