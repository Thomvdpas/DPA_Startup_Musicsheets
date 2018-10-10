using DPA_Musicsheets.Enums;
using DPA_Musicsheets.Models;

namespace DPA_Musicsheets.Builders
{
    public class NoteBuilder : AbstractBuilder<NoteBuilder, MusicNote>
    {
        public NoteBuilder(PitchType pitchType)
        {
            Note = new MusicNote { PitchType = pitchType };
        }
        public void Sharp()
        {
            Note.PitchType = PitchType.Sharp;
        }

        public void Flat()
        {
            Note.PitchType = PitchType.Flat;
        }

        public void IncreaseOctave()
        {
            Note.Octaves++;
        }

        public void DecreaseOctave()
        {
            Note.Octaves--;
        }

        public void ChangeOctave(int value)
        {
            Note.Octaves += value;
        }

        public void IsTied(bool isTied = true)
        {
            Note.IsTied = isTied;
        }
    }
}
