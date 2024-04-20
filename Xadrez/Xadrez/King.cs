using Xadrez.Board;
namespace Xadrez.Xadrez
{
    class King : Piece
    {
        public King(BoardGame board, Color color) : base(board, color) 
        {

        }
        public override string ToString()
        {
            return "K";
        }
    }
}
