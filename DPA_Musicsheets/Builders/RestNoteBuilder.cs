using DPA_Musicsheets.Models;

namespace DPA_Musicsheets.Builders
{
    public class RestNoteBuilder : AbstractNoteBuilder
    {
        public RestNoteBuilder()
        {
            BaseNote = new RestNote();
        }
    }
}
