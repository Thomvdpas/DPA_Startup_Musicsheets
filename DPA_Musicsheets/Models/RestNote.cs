using DPA_Musicsheets.Enums;

namespace DPA_Musicsheets.Models
{
    public class RestNote : BaseNote
    {
        public RestNote(Duration duration) : base(NoteType.Empty, duration)
        {
            Duration = duration;
        }
    }

}