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
                ChessPlay chessPlay = new ChessPlay();
                while (!chessPlay.isOver)
                {
                    Console.Clear();
                    Screen.PrintBoard(chessPlay.Board);
                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadPositionChess().ToPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadPositionChess().ToPosition();
                    chessPlay.Movement(origin, destiny);
                }             
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }       
        }
    }
}
