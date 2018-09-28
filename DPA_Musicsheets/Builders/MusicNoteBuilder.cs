using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA_Musicsheets.Enums;
using DPA_Musicsheets.Models;

namespace DPA_Musicsheets.Builders
{
    public class MusicNoteBuilder : AbstractNoteBuilder
    {

        public MusicNoteBuilder(NoteType noteType)
        {
            BaseNote = new MusicNote(noteType);
        }

        public void Sharp()
        {
            BaseNote.PitchType = PitchType.Sharp;
        }

        public void Flat()
        {
            BaseNote.PitchType = PitchType.Flat;
        }

    }
}
