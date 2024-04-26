using Xadrez.Board;
namespace Xadrez.Xadrez
{
    class Bishop : Piece
    {
        public Bishop(BoardGame board, Color color) : base(board, color){}
        public override string ToString()
        {
            return "B";
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
            int[,] directions = { { -1, -1 }, { -1, 1 }, { 1, 1 }, { 1, -1 } };

            for (int i = 0; i < 4; i++)
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
                    if (Board.ReturnPiece(pos) != null && Board.ReturnPiece(pos).Color != Color)
                        break;
                }
            }
            return mat;
        }
    }
}