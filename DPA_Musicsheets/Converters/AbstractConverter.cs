using DPA_Musicsheets.Models;

namespace DPA_Musicsheets.Converters
{
    public abstract class AbstractMusicConverter<T> where T : class
    {
        public abstract T Convert(Piece input);
    }
}