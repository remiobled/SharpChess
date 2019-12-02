using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessEngine
{
    public class King : Piece
    {
        private int _initialeLine;

        public King(PieceColor color, int initialeLine) : base(color)
        {
            _initialeLine = initialeLine;
        }

        internal List<PiecePosition> GetPossiblePiecePositionsWithoutRoque(PiecePosition position, Board board)
        {
            return new List<PiecePosition>
            {
                new PiecePosition((char)(position.Column - 1), position.Line - 1),
                new PiecePosition((char)(position.Column - 1), position.Line),
                new PiecePosition((char)(position.Column - 1), position.Line + 1),
                new PiecePosition(position.Column, position.Line + 1),
                new PiecePosition(position.Column, position.Line - 1),
                new PiecePosition((char)(position.Column + 1), position.Line - 1),
                new PiecePosition((char)(position.Column + 1), position.Line),
                new PiecePosition((char)(position.Column + 1), position.Line + 1)
            }
            .Where(x => IsInBoard(x) && !IsOccupiedBySameColorPiece(board, x) && !board.IsPositionThreatened(x, Color))
            .ToList();
        }

        internal override List<PiecePosition> GetPossiblePiecePositions(PiecePosition position, Board board)
        {

            var positions = GetPossiblePiecePositionsWithoutRoque(position, board);
            if (CanBigRoque(board))
            {
                positions.Add(new PiecePosition('A', _initialeLine));
            }
            if (CanSmallRoque(board))
            {
                positions.Add(new PiecePosition('H', _initialeLine));
            }
            return positions;
        }


        private bool CanBigRoque(Board board)
        {
            if (HasMoved)
            {
                return false;
            }
            var rook = board.GetPiece(new PiecePosition('A', _initialeLine));
            if (rook.HasMoved)
            {
                return false;
            }
            for(char col = 'B'; col<='D'; col++)
            {
                var piecePosition = new PiecePosition(col, _initialeLine);
                if(board.GetPiece(piecePosition) != null || board.IsPositionThreatened(piecePosition, Color))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CanSmallRoque(Board board)
        {
            if (HasMoved)
            {
                return false;
            }
            var rook = board.GetPiece(new PiecePosition('H', _initialeLine));
            if (rook.HasMoved)
            {
                return false;
            }
            for (char col = 'F'; col <= 'G'; col++)
            {
                var piecePosition = new PiecePosition(col, _initialeLine);

                

                if (board.GetPiece(piecePosition) != null || board.IsPositionThreatened(piecePosition, Color))
                {
                    return false;
                }
            }
            return true;
        }
    }
}