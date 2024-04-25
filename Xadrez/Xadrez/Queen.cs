using Xadrez.Board;
namespace Xadrez.Xadrez
{
    class Queen : Piece
    {
        public Queen(BoardGame board, Color color) : base(board, color) { }
        public override string ToString()
        {
            return "Q";
        }
        private bool CanMove(Position pos)
        {
            Piece p = Board.ReturnPiece(pos);
            return p == null || p.Color != Color;
        }
        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);
            int[,] directions = { { 0, -1 }, { 0, 1 }, {-1 ,0 }, { 1, 0 },{ -1, -1 }, { -1, 1 }, { 1, 1 }, { 1, -1 } };

            for (int i = 0; i < 8; i++)
            {
                int line = Position.Line;
                int column = Position.Column;
                while (true)
                {
                    line += directions[i, 0];
                    column += directions[i, 1];
                    pos.defValues(line, column);
                    if (Board.ValidPosition(pos) && CanMove(pos))
                    {                    
                        mat[pos.Line, pos.Column] = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return mat;
        }
    }
}
