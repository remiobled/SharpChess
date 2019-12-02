using System;
using System.Collections.Generic;

namespace ChessEngine
{
    public class LocalPlayer : IPlayer
    {
        public PieceColor Color { get; }
        private readonly Action<Board, List<PiecePosition>> _renderBoard;

        public LocalPlayer(PieceColor color, Action<Board, List<PiecePosition>> renderBoard)
        {
            Color = color;
            _renderBoard = renderBoard;
        }

        public void Play(Board board)
        {
            Console.WriteLine("ShowMoves [position]; Move [initial_position] [destination_position]; IsThreatened [position]; EXIT");
            Console.Write("->");
            var instruction = Console.ReadLine().Split(' ');
            switch (instruction[0].ToLower())
            {
                case "sm":
                    var possibleMoves = board.GetPossiblePiecePositions(GetPositionInInstruction(instruction, 1));
                    _renderBoard(board, possibleMoves);
                    Play(board);
                    break;
                case "m":
                    var fromPosition = GetPositionInInstruction(instruction, 1);
                    var toPosition = GetPositionInInstruction(instruction, 2);
                    if (!board.Move(this, fromPosition, toPosition))
                    {
                        Play(board);
                    }
                    break;
                case "it":
                    if(board.IsPositionThreatened(GetPositionInInstruction(instruction, 1), Color))
                    {
                        Console.WriteLine("This Position is threatened");
                    }
                    else
                    {
                        Console.WriteLine("This Position is not threatened");
                    }
                    Play(board);
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Play(board);
                    break;
            }
        }

        private PiecePosition GetPositionInInstruction(string[] instruction, int argumentIndex)
        {
            return new PiecePosition(instruction[argumentIndex][0], Convert.ToInt32(instruction[argumentIndex][1].ToString()));
        }
    }
}