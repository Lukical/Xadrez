using Xadrez.Board;

namespace Xadrez
{
    class Program
    {
        public static void Main(string[] args)
        {
            BoardGame board = new BoardGame(8, 8);
            Screen.printBoard(board);
            Console.WriteLine();
        }
    }
}
