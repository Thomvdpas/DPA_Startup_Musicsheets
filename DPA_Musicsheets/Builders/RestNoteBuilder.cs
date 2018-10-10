using DPA_Musicsheets.Models;

namespace DPA_Musicsheets.Builders
{
    public class RestNoteBuilder : AbstractBuilder<RestNoteBuilder, RestNote>
    {
        public RestNoteBuilder()
        {
            Note = new RestNote();
        }
    }
}
