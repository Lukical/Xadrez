﻿using Xadrez.Board;
using Xadrez.Xadrez;
namespace Xadrez
{
    class Screen
    {
        public static void PrintBoard(BoardGame board)
        {
            for (int i = 0; i < board.Lines;  i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < board.Columns; j++)
                {
                    if(board.ReturnPiece(i, j) == null)
                    {
                        Console.Write("- ");
                        continue;
                    }
                    PrintPiece(board.ReturnPiece(i, j));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
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
            if(piece.Color == Color.White)
            {
                Console.Write(piece);
                return;
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(piece);
            Console.ForegroundColor = aux;  
        }
    }
}
