using Xadrez.Board;
namespace Xadrez
{
    class Screen
    {
        public static void PrintBoard(BoardGame board)
        {
            for (int i = 0; i < board.Lines;  i++)
            {
                for(int j = 0; j < board.Columns; j++)
                {
                    if(board.ReturnPiece(i, j) == null)
                    {
                        Console.Write("- ");
                        continue;
                    }
                    Console.Write($"{board.ReturnPiece(i, j)} ");
                }
                Console.WriteLine();
            }
        }
    }
}
