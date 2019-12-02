using System.Collections.Generic;

namespace ChessEngine
{
    public class Bishop : Piece
    {
        public Bishop(PieceColor color) : base(color)
        {
        }

        internal override List<PiecePosition> GetPossiblePiecePositions(PiecePosition position, Board board)
        {
            return GetDiagonalMoves(position, board);
        }
    }
}
