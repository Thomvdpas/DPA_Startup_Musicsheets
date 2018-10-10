using DPA_Musicsheets.Enums;
using DPA_Musicsheets.Models.Base;

namespace DPA_Musicsheets.Models
{
    public class RestNote : BaseNote
    {
        public RestNote()
        {
            NoteType = NoteType.Rest;
        }

        public override BaseNote ShallowClone()
        {
            return (RestNote) MemberwiseClone();
        }

        public override BaseNote Clone()
        {
            return new RestNote();
        }
    }
}