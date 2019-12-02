using System;
using System.Collections.Generic;

namespace ChessEngine
{
    public class Pawn : Piece
    {
        private int _direction;

        public Pawn(PieceColor color, int direction) : base(color)
        {
            _direction = direction;
        }

        internal override List<PiecePosition> GetPossiblePiecePositions(PiecePosition position, Board board)
        {
            var positions = new List<PiecePosition>();
            var maxStep = HasMoved ? 1 : 2;

            int line = position.Line;
            while (IsInBoard(position.Column, line) && Math.Abs(line - position.Line) < maxStep)
            {
                line = line + 1 * _direction;
                var newPosition = new PiecePosition(position.Column, line);
                
                if(IsOccupiedBySameColorPiece(board, newPosition) || IsOccupiedByOtherColorPiece(board, newPosition))
                {
                    break;
                }
                positions.Add(newPosition);
            }

            var diagonal1Position = new PiecePosition((char)(position.Column - 1), position.Line + _direction);
            if(IsInBoard(diagonal1Position) && IsOccupiedByOtherColorPiece(board, diagonal1Position))
            {
                positions.Add(diagonal1Position);
            }

            var diagonal2Position = new PiecePosition((char)(position.Column + 1), position.Line + _direction);
            if (IsInBoard(diagonal2Position) && IsOccupiedByOtherColorPiece(board, diagonal2Position))
            {
                positions.Add(diagonal2Position);
            }
            return positions;
        }
    }
}