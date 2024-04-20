using Xadrez.Board;
using Xadrez.Xadrez;

namespace Xadrez
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                BoardGame board = new BoardGame(8, 8);
                board.PutPiece(new Tower(board, Color.Black), new Position(0, 0));
                board.PutPiece(new King(board, Color.Black), new Position(0, 2));
                Screen.PrintBoard(board);
                Console.WriteLine();
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
