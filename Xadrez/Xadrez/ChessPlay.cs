using Xadrez.Board;
namespace Xadrez.Xadrez
{
    class ChessPlay
    {
        public BoardGame Board { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool IsOver {  get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> OutPieces;
        public bool Check { get; private set; }

        public ChessPlay()
        {
            Board = new BoardGame(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            IsOver = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            OutPieces = new HashSet<Piece>();
            PutPieces();
        }
        public Piece Movement(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncrementMovements();
            Piece e = Board.RemovePiece(destiny);
            Board.PutPiece(p, destiny);
            if(e != null)
            {
                OutPieces.Add(e);
            }
            return e;
        }
        public void BackMovement(Position origin, Position destiny, Piece piece)
        {
            Piece p = Board.RemovePiece(destiny);
            p.DecrementMovements();
            if(piece != null)
            {
                Board.PutPiece(piece, destiny);
                OutPieces.Remove(piece);
            }
            Board.PutPiece(p, origin);
        }
        public HashSet<Piece> ListOutPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece piece in OutPieces)
            {
                if(piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }
        public HashSet<Piece> ListReamainingPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(ListOutPieces(color));
            return aux;
        }
        private Color Enemy(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            return Color.White;
        }
        private Piece IsKing(Color color)
        {
            foreach(Piece p in ListReamainingPieces(color))
            {
                if(p is King)
                {
                    return p;
                }
            }
            return null;
        }
        public bool IsCheckmate(Color color)
        {
            Piece k = IsKing(color);
            if (k == null) throw new BoardException("King not found!");
            foreach(Piece p in ListReamainingPieces(Enemy(color)))
            {
                bool[,] mat = p.PossibleMoviments();
                if (mat[k.Position.Line, k.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }
        public void PutNewPieces(char column, int line, Piece piece) 
        {
            Board.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }
        private void PutPieces()
        {
            PutNewPieces('c', 1, new Tower(Board, Color.White));
            PutNewPieces('d', 1, new King(Board, Color.White));
            PutNewPieces('e', 1, new Tower(Board, Color.White));
            PutNewPieces('c', 2, new Tower(Board, Color.White));
            PutNewPieces('d', 2, new Tower(Board, Color.White));
            PutNewPieces('e', 2, new Tower(Board, Color.White));

            PutNewPieces('d', 7, new Tower(Board, Color.Black));
            PutNewPieces('c', 7, new Tower(Board, Color.Black));
            PutNewPieces('e', 7, new Tower(Board, Color.Black));
            PutNewPieces('d', 8, new King(Board, Color.Black));
        }
        public void RealizePlay(Position origin, Position destiny)
        {
            Piece e = Movement(origin, destiny);
            if (IsCheckmate(ActualPlayer))
            {
                BackMovement(origin, destiny, e);
                throw new BoardException("You are in check!");
            }
            if(IsCheckmate(Enemy(ActualPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            Turn++;
            changePlayer();
        }
        public void ValidOriginPosition(Position pos)
        {
            if(Board.ReturnPiece(pos) == null)
            {
                throw new BoardException("Does not exists piece on this location.");
            }
            if(ActualPlayer != Board.ReturnPiece(pos).Color)
            {
                throw new BoardException("Choose your piece color to move.");
            }
            if (!Board.ReturnPiece(pos).ExistsPossibleMoviments())
            {
                throw new BoardException("Don't have any possible moviments for this piece.");
            }
        }
        public void ValidDestinyPosition(Position origin, Position destiny)
        {
            if (!Board.ReturnPiece(origin).CanMoveto(destiny))
            {
                throw new BoardException("Destiny position invalid!");
            }
        }
        public void changePlayer() 
        {
            if(ActualPlayer == Color.White)
            {
                ActualPlayer = Color.Black;
                return;
            }
            ActualPlayer = Color.White;
        }
    }
}
