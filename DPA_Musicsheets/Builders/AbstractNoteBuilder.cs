using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Enums;
using DPA_Musicsheets.Models;

namespace DPA_Musicsheets.Builders
{
    public class AbstractNoteBuilder
    {
        protected BaseNote BaseNote;

        public BaseNote GetNote()
        {
            return BaseNote;
        }

        public void IsPoint()
        {
            BaseNote.IsPoint = true;
        }

        public void Duration(double duration)
        {
            BaseNote.Duration = duration;
        }
    }
}
