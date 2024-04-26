using Xadrez.Board;
namespace Xadrez.Xadrez
{
    class King : Piece
    {
        private ChessPlay ChessPlay;
        public King(BoardGame board, Color color, ChessPlay chessPlay) : base(board, color) 
        {
            ChessPlay = chessPlay;
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
        private bool TowerCastling(Position pos)
        {
            Piece p = Board.ReturnPiece(pos);
            return p!= null && p is Tower && p.Color == Color && p.Movements == 0;
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

            //Castling
            if (Movements == 0 && !ChessPlay.Check)
            {
                //Small
                Position posT1 = new Position(Position.Line, Position.Column + 3);                
                if (TowerCastling(posT1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if(Board.ReturnPiece(p1) == null && Board.ReturnPiece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }

                //Big
                Position posT2 = new Position(Position.Line, Position.Column - 4);
                if (TowerCastling(posT2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.ReturnPiece(p1) == null && Board.ReturnPiece(p2) == null && Board.ReturnPiece(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }

            }

            return mat;
        }
    }
}
