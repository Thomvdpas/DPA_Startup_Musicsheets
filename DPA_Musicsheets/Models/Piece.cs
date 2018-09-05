using System.Collections.Generic;
using System.Linq;

namespace DPA_Musicsheets.Models
{
    public class Piece
    {
        public List<Repetition> Repetitions { get; private set; }
        public Signature Signature { get; private set; }
        public LinkedList<BaseNote> Notes { get; private set; }

        public Piece(Signature signature)
        {
            Repetitions = new List<Repetition>();
            Signature = signature;
            Notes = new LinkedList<BaseNote>();
        }

        public void Add(BaseNote note)
        {
            Notes.AddLast(note);
        }

        public void Add(IList<BaseNote> notes)
        {
            notes.ToList().ForEach(note => Notes.AddLast(note));
        }
    }
}