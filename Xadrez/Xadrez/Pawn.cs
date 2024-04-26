using Xadrez.Board;
namespace Xadrez.Xadrez
{
    class Pawn : Piece
    {
        private ChessPlay ChessPlay;
        public Pawn(BoardGame board, Color color, ChessPlay chessPlay) : base(board, color)
        {
            ChessPlay = chessPlay;
        }
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

                //Passant
                if(Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if(Board.ValidPosition(left) && HaveEnemy(left) && Board.ReturnPiece(left) == ChessPlay.IsInPassant)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(right) && HaveEnemy(right) && Board.ReturnPiece(right) == ChessPlay.IsInPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
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
                //Passant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(left) && HaveEnemy(left) && Board.ReturnPiece(left) == ChessPlay.IsInPassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(right) && HaveEnemy(right) && Board.ReturnPiece(right) == ChessPlay.IsInPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}

