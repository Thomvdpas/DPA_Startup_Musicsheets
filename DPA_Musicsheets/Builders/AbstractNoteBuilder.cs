using DPA_Musicsheets.Models.Base;

namespace DPA_Musicsheets.Builders
{
    public class AbstractBuilder<TBuilder, TNote> where TBuilder : AbstractBuilder<TBuilder, TNote> where TNote : BaseNote
    {
        protected TNote Note;

        public TNote Build()
        {
            return Note;
        }

        public void IsDotted(int dots = 1)
        {
            Note.Dots = dots;
        }

        public void AddDots(int dots = 1)
        {
            Note.Dots += dots;
        }

        public void Duration(Enums.DurationType duration)
        {
            Note.DurationType = duration;
        }
    }
}