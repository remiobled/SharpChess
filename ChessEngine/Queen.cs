using System.Collections.Generic;
using System.Linq;

namespace ChessEngine
{
    public class Queen : Piece
    {
        public Queen(PieceColor color) : base(color)
        {
        }

        internal override List<PiecePosition> GetPossiblePiecePositions(PiecePosition position, Board board)
        {
            return GetForwardBackwardMoves(position, board).Union(GetDiagonalMoves(position, board)).ToList();
        }
    }
}
