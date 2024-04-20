using Xadrez.Board;
namespace Xadrez.Xadrez
{
    class Tower : Piece
    {
        public Tower(BoardGame board, Color color) : base(board, color) 
        {

        }
        public override string ToString()
        {
            return "T";
        }
    }
}
