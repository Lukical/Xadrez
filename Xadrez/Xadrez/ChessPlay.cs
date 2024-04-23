using Xadrez.Board;
namespace Xadrez.Xadrez
{
    class ChessPlay
    {
        public BoardGame Board { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool isOver {  get; private set; }

        public ChessPlay()
        {
            Board = new BoardGame(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            isOver = false;
            PutPieces();
        }
        public void Movement(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncrementMovements();
            Piece e = Board.RemovePiece(destiny);
            Board.PutPiece(p, destiny);
        }
        private void PutPieces()
        {
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
        }
        public void RealizePlay(Position origin, Position destiny)
        {
            Movement(origin, destiny);
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
