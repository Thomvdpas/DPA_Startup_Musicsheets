using System.Collections.Generic;
using System.Linq;

namespace DPA_Musicsheets.Models
{
    public class Composition
    {
        public LinkedList<Piece> Pieces { get; }

        public Composition()
        {
            Pieces = new LinkedList<Piece>();
        }

        public void Add(Piece piece)
        {
            Pieces.AddLast(piece);
        }

        public void Add(IList<Piece> pieces)
        {
            Pieces.ToList().ForEach(piece => Pieces.AddLast(piece));
        }
    }
}