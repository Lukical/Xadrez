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
        private bool CanMove(Position pos)
        {
            Piece p = Board.ReturnPiece(pos);
            return p == null || p.Color != Color;
        }
        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);
            int[] directions = { -1, 1, 0, 0 };

            for (int i = 0; i < 4; i++)
            {
                int line = Position.Line;
                int column = Position.Column;
                while (true)
                {
                    line += directions[i];
                    column += directions[(i + 2) % 4];
                    pos.defValues(line, column);
                    if (!Board.ValidPosition(pos) || !CanMove(pos)) break;
                    mat[pos.Line, pos.Column] = true;
                    if (Board.ReturnPiece(pos) != null && Board.ReturnPiece(pos).Color != Color) break; 
                }
            }
            return mat;
        }
    }
}
