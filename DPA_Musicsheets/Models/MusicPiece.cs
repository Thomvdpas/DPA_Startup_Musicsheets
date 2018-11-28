namespace DPA_Musicsheets.Models
{
    public class MusicPiece : Piece
    {
        public int Division { get; set; }

        public MusicPiece(int division)
        {
            Division = division;
        }
    }
}