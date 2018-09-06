using System.Collections.Generic;
using System.Linq;
using DPA_Musicsheets.Interfaces;

namespace DPA_Musicsheets.Models
{
    public class Piece : ICloneable<Piece>
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

        public Piece(Signature signature, IList<Repetition> repetitions, LinkedList<BaseNote> notes)
        {
            Repetitions = (List<Repetition>) repetitions;
            Signature = signature;
            Notes = notes;
        }

        public void Add(BaseNote note)
        {
            Notes.AddLast(note);
        }

        public void Add(IList<BaseNote> notes)
        {
            notes.ToList().ForEach(note => Notes.AddLast(note));
        }

        public Piece ShallowClone()
        {
            return (Piece) MemberwiseClone();
        }

        public Piece Clone()
        {
            return new Piece(Signature, Repetitions, Notes);
        }

    }
}