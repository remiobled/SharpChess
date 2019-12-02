using System.Collections.Generic;

namespace ChessEngine
{
    public class Knight : Piece
    {
        public Knight(PieceColor color) : base(color)
        {
        }

        internal override List<PiecePosition> GetPossiblePiecePositions(PiecePosition position, Board board)
        {
            var positions = new List<PiecePosition>();

            var newPosition = new PiecePosition((char)(position.Column + 2), position.Line + 1);
            if (IsInBoard(newPosition) && !IsOccupiedBySameColorPiece(board, newPosition))
            {
                positions.Add(newPosition);
            }

            newPosition = new PiecePosition((char)(position.Column + 1), position.Line + 2);
            if (IsInBoard(newPosition) && !IsOccupiedBySameColorPiece(board, newPosition))
            {
                positions.Add(newPosition);
            }

            newPosition = new PiecePosition((char)(position.Column - 2), position.Line - 1);
            if (IsInBoard(newPosition) && !IsOccupiedBySameColorPiece(board, newPosition))
            {
                positions.Add(newPosition);
            }

            newPosition = new PiecePosition((char)(position.Column - 1), position.Line - 2);
            if (IsInBoard(newPosition) && !IsOccupiedBySameColorPiece(board, newPosition))
            {
                positions.Add(newPosition);
            }

            newPosition = new PiecePosition((char)(position.Column + 2), position.Line - 1);
            if (IsInBoard(newPosition) && !IsOccupiedBySameColorPiece(board, newPosition))
            {
                positions.Add(newPosition);
            }

            newPosition = new PiecePosition((char)(position.Column - 1), position.Line + 2);
            if (IsInBoard(newPosition) && !IsOccupiedBySameColorPiece(board, newPosition))
            {
                positions.Add(newPosition);
            }

            newPosition = new PiecePosition((char)(position.Column - 2), position.Line + 1);
            if (IsInBoard(newPosition) && !IsOccupiedBySameColorPiece(board, newPosition))
            {
                positions.Add(newPosition);
            }

            newPosition = new PiecePosition((char)(position.Column + 1), position.Line - 2);
            if (IsInBoard(newPosition) && !IsOccupiedBySameColorPiece(board, newPosition))
            {
                positions.Add(newPosition);
            }

            return positions;
        }
    }
}
