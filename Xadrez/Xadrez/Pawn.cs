using Xadrez.Board;
namespace Xadrez.Xadrez
{
    class Pawn : Piece
    {
        public Pawn(BoardGame board, Color color) : base(board, color){}
        public override string ToString()
        {
            return "P";
        }
        private bool HaveEnemy(Position pos)
        {
            Piece p = Board.ReturnPiece(pos);
            return p != null && p.Color != Color;
        }
        private bool FreeSpace(Position pos)
        {
            return Board.ReturnPiece(pos) == null;
        }
        public override bool[,] PossibleMoviments()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);
            
            if(Color == Color.White)
            {
                pos.defValues(Position.Line - 1, Position.Column);
                if(Board.ValidPosition(pos) && FreeSpace(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(pos) && FreeSpace(pos) && Movements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.defValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(pos) && FreeSpace(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(pos) && FreeSpace(pos) && Movements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.defValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && HaveEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }

            return mat;
        }
    }
}

