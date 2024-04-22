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
        private bool CanMove(Position pos)
        {
            Piece p = Board.ReturnPiece(pos);
            return p == null || p.Color != Color;
        }
        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0,0);
            int[,] directions = { { -1, 0 }, { -1, 1 }, { 0, 1 }, { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 } };

            for (int i = 0; i < 8; i++)
            {
                int line = Position.Line + directions[i, 0];
                int column = Position.Column + directions[i, 1];
                pos.defValues(line, column);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            return mat;
        }
    }
}
