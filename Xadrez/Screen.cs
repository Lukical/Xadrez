using Xadrez.Board;
using Xadrez.Xadrez;
namespace Xadrez
{
    class Screen
    {
        public static void PrintChessPlay(ChessPlay chessPlay)
        {
            Screen.PrintBoard(chessPlay.Board);
            Console.WriteLine();
            PrintOutPieces(chessPlay);
            Console.WriteLine();
            Console.WriteLine($"Turn: {chessPlay.Turn}");
            Console.WriteLine($"Waiting {chessPlay.ActualPlayer} player moviment");
            if (chessPlay.Check)
            {
                Console.WriteLine("Check!");
            }
        }
        public static void PrintOutPieces(ChessPlay chessPlay)
        {
            Console.WriteLine("Pieces out:");
            Console.Write("White: ");
            PrintGroup(chessPlay.ListOutPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintGroup(chessPlay.ListOutPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void PrintGroup(HashSet<Piece> group)
        {
            Console.Write("[");
            foreach (Piece p in group)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(BoardGame board)
        {
            for (int i = 0; i < board.Lines;  i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.ReturnPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintBoard(BoardGame board, bool[,] posiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (posiblePositions[i, j])
                    {
                        Console.BackgroundColor = newBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.ReturnPiece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = originalBackground;
            Console.WriteLine("  a b c d e f g h");
        }
        public static ChessPosition ReadPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }
        public static void PrintPiece(Piece piece) 
        { 
            if(piece == null)
            {
                Console.Write("- ");
                return;
            }
            if(piece.Color == Color.White)
            {
                Console.Write(piece);
                Console.Write(" ");
                return;
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(piece);
            Console.ForegroundColor = aux;
            Console.Write(" ");
        }       
    }
}
