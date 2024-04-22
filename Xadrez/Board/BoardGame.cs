namespace Xadrez.Board
{
    class BoardGame
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public BoardGame(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines, Columns];
        }
        public Piece ReturnPiece(int line, int column) 
        {
            return Pieces[line, column];
        }
        public Piece ReturnPiece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }
        public void PutPiece(Piece p, Position pos)
        {
            if (SearchPiece(pos))
            {
                throw new BoardException("Alread exists a piece in this location!");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }
        public Piece RemovePiece(Position pos)
        {
            if (ReturnPiece(pos) == null)
            {
                return null;
            }
            Piece aux = ReturnPiece(pos);
            aux.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return aux;
        }
        public bool SearchPiece(Position pos)
        {
            ValidatePosition(pos);
            return ReturnPiece(pos) != null;
        }
        public bool ValidPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }
        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
