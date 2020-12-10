using System;
using System.Collections.Generic;
using ChessEngine;

namespace ChessConsole
{
    public static class BoardRenderer
    {
        static BoardRenderer()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }

        public static void RenderBoard(Board board, List<PiecePosition> highlightedPositions = null)
        {
            for (int l = 8; l >= 1; l--)
            {
                SetNeutralConsoleColor();
                Console.Write(Environment.NewLine);
                Console.Write(l);
                for (int c = 0; c < 8; c++)
                {
                    var piecePosition = new PiecePosition((char)(c + 'A'), l);
                    var piece = board.GetPiece(piecePosition);
                    Console.ForegroundColor = ToForegroundConsoleColor(piece?.Color);
                    Console.BackgroundColor = BackgroundColor(piecePosition, highlightedPositions);
                    Console.Write(" " + PieceRepresentation(piece) + " ");
                }
            }
            SetNeutralConsoleColor();
            Console.Write(Environment.NewLine);
            Console.Write(" ");
            for (int l = 0; l < 8; l++)
            {
                Console.Write(" " + (char)(l + 'A') + " ");
            }
            Console.Write(Environment.NewLine);
        }

        private static void SetNeutralConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static ConsoleColor BackgroundColor(PiecePosition piecePosition, List<PiecePosition> highlightedPositions)
        {
            if (highlightedPositions?.Contains(piecePosition) ?? false)
            {
                return ConsoleColor.Cyan;
            }
            else
            {
                return (piecePosition.Line + piecePosition.Column) % 2 == 0 ? ConsoleColor.Gray : ConsoleColor.DarkBlue;
            }
        }

        private static ConsoleColor ToForegroundConsoleColor(PieceColor? pieceColor)
        {
            if (pieceColor == PieceColor.Black)
            {
                return ConsoleColor.Black;
            }
            if (pieceColor == PieceColor.White)
            {
                return ConsoleColor.White;
            }
            return ConsoleColor.White;
        }

        private static char PieceRepresentation(Piece piece)
        {
            if (piece == null)
            {
                return ' ';
            }
            if (piece is Pawn)
            {
                return (char)0x2659;
            }
            if (piece is Rook)
            {
                return (char)0x2656;
            }
            if (piece is Knight)
            {
                return (char)0x2658;
            }
            if (piece is Bishop)
            {
                return (char)0x2657;
            }
            if (piece is Queen)
            {
                return (char)0x2655;
            }
            if (piece is King)
            {
                return (char)0x2654;
            }
            throw new ArgumentException();
        }
    }
}