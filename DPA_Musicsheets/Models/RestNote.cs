using DPA_Musicsheets.Enums;

namespace DPA_Musicsheets.Models
{
    public class RestNote : BaseNote
    {
        public RestNote(double duration) : base(PitchType.None, NoteType.Empty, duration)
        {

        }

        public override BaseNote Clone()
        {
            return new RestNote(Duration);
        }
    }

}