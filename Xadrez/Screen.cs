using Xadrez.Board;
namespace Xadrez
{
    class Screen
    {
        public static void printBoard(BoardGame board)
        {
            for (int i = 0; i < board.Lines;  i++)
            {
                for(int j = 0; j < board.Columns; j++)
                {
                    if(board.piece(i, j) == null)
                    {
                        Console.Write("- ");
                        continue;
                    }
                    Console.Write($"{board.piece(i, j)} ");
                }
                Console.WriteLine();
            }
        }
    }
}
