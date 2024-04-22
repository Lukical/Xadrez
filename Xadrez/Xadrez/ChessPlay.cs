using Xadrez.Board;
namespace Xadrez.Xadrez
{
    class ChessPlay
    {
        public BoardGame Board { get; private set; }
        private int Turn;
        private Color ActualPlayer;
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
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
        }
    }
}
