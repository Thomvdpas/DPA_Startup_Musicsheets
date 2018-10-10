using DPA_Musicsheets.Models.Base;

namespace DPA_Musicsheets.Models
{
    public class Repetition
    {
        public BaseNote StartPosition { get; }
        public BaseNote EndPosition { get; }
        public BaseNote AlternativePosition { get; private set; }

        public Repetition(BaseNote startPosition, BaseNote endPosition, BaseNote alternativePosition = null)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
            AlternativePosition = alternativePosition;
        }
    }
}
