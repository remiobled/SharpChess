using System;
using System.Collections.Generic;

namespace ChessEngine
{
    public class ChessGame
    {
        public readonly Action<Board, List<PiecePosition>> RenderBoard;
        public readonly Board Board;
        public IPlayer Player1 { get; }
        public IPlayer Player2 { get; }

        public ChessGame(IPlayer player1, IPlayer player2, Action<Board, List<PiecePosition>> renderBoard)
        {
            RenderBoard = renderBoard;
            if(player1.Color == player2.Color)
            {
                throw new Exception($"Player 1 and 2 cannot be both {player1.Color.ToString()}");
            }
            Player1 = player1;
            Player2 = player2;

            Board = new Board(player1.Color, player2.Color);
        }

        public void StartGame()
        {
            RenderBoard(Board, null);
            while (true)
            {
                Console.WriteLine($"Player 1 ({Player1.Color}) plays:");
                Player1.Play(Board);
                RenderBoard(Board, null);
                if(Board.Winner!= null)
                {
                    Console.WriteLine($"{Board.Winner.Color} wins!");
                    break;
                }
                Console.WriteLine($"Player 2 ({Player2.Color}) plays:");
                Player2.Play(Board);
                RenderBoard(Board, null);
                if (Board.Winner != null)
                {
                    Console.WriteLine($"{Board.Winner.Color} wins!");
                    break;
                }
            }
        }
    }
}
