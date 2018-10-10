using DPA_Musicsheets.Models;

namespace DPA_Musicsheets.Commands
{
    public abstract class AbstractCommand
    {
        public Piece Piece { get; set; }

        public string LilypondText { get; set; }

        public abstract void Execute();
    }
}