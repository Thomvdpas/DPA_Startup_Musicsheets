using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
