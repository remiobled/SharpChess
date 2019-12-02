using System;

namespace ChessEngine
{
    public class PiecePosition : IEquatable<PiecePosition>
    {
        public char Column { get; }
        public int Line { get; }

        public PiecePosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public bool Equals(PiecePosition other)
        {
            if(other == null)
            {
                return false;
            }
            return other.Column == Column && other.Line == Line;
        }
    }
}
