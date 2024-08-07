﻿using Xadrez.Board;
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
                while (!chessPlay.IsOver)
                {
                    try { 
                        Console.Clear();
                        Screen.PrintChessPlay(chessPlay);
                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadPositionChess().ToPosition();
                        chessPlay.ValidOriginPosition(origin);
                        bool[,] possiblePositions = chessPlay.Board.ReturnPiece(origin).PossibleMoviments();
                        Console.Clear();
                        Screen.PrintBoard(chessPlay.Board, possiblePositions);
                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadPositionChess().ToPosition();
                        chessPlay.ValidDestinyPosition(origin, destiny);
                        chessPlay.RealizePlay(origin, destiny);
                    } 
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintChessPlay(chessPlay);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }       
        }
    }
}
