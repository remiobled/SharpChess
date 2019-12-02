using System.Collections.Generic;

namespace ChessEngine
{
    public class Rook : Piece
    {
        public Rook(PieceColor color) : base(color)
        {
        }

        internal override List<PiecePosition> GetPossiblePiecePositions(PiecePosition position, Board board)
        {
            return GetForwardBackwardMoves(position, board);
        }
    }
}
