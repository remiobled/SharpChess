using System.Collections.Generic;

namespace ChessEngine
{
    public abstract class Piece
    {
        public PieceColor Color;
        internal bool HasMoved;

        internal abstract List<PiecePosition> GetPossiblePiecePositions(PiecePosition position, Board board);

        protected Piece(PieceColor color)
        {
            Color = color;
        }

        public void Move()
        {
            HasMoved = true;
        }

        protected bool IsInBoard(char column, int line)
        {
            return column >= 'A' && column <= 'H' && line >= 1 && line <= 8;
        }

        protected bool IsInBoard(PiecePosition position)
        {
            return IsInBoard(position.Column, position.Line);
        }

        protected bool IsOccupiedBySameColorPiece(Board board, PiecePosition position)
        {
            var newPiece = board.GetPiece(position);
            return newPiece?.Color == Color;
        }

        protected bool IsOccupiedByOtherColorPiece(Board board, PiecePosition position)
        {
            var newPiece = board.GetPiece(position);
            return newPiece != null && newPiece?.Color != Color;
        }

        protected List<PiecePosition> GetForwardBackwardMoves(PiecePosition position, Board board)
        {
            var positions = new List<PiecePosition>();
            int line = position.Line + 1;
            while (IsInBoard(position.Column, line))
            {
                var newPosition = new PiecePosition(position.Column, line);
                if (IsOccupiedBySameColorPiece(board, newPosition))
                {
                    break;
                }
                positions.Add(newPosition);
                if (IsOccupiedByOtherColorPiece(board, newPosition))
                {
                    break;
                }
                line++;
            }
            line = position.Line - 1;
            while (IsInBoard(position.Column, line))
            {
                var newPosition = new PiecePosition(position.Column, line);
                if (IsOccupiedBySameColorPiece(board, newPosition))
                {
                    break;
                }
                positions.Add(newPosition);
                if (IsOccupiedByOtherColorPiece(board, newPosition))
                {
                    break;
                }
                line--;
            }

            char column = (char)(position.Column + 1);
            while (IsInBoard(column, position.Line))
            {
                var newPosition = new PiecePosition(column, position.Line);
                if (IsOccupiedBySameColorPiece(board, newPosition))
                {
                    break;
                }
                positions.Add(newPosition);
                if (IsOccupiedByOtherColorPiece(board, newPosition))
                {
                    break;
                }
                column++;
            }
            column = (char)(position.Column - 1);
            while (IsInBoard(column, position.Line))
            {
                var newPosition = new PiecePosition(column, position.Line);
                if (IsOccupiedBySameColorPiece(board, newPosition))
                {
                    break;
                }
                positions.Add(newPosition);
                if (IsOccupiedByOtherColorPiece(board, newPosition))
                {
                    break;
                }
                column--;
            }
            return positions;
        }

        protected List<PiecePosition> GetDiagonalMoves(PiecePosition position, Board board)
        {
            var positions = new List<PiecePosition>();
            int line = position.Line + 1;
            char column = (char)(position.Column + 1);
            while (IsInBoard(column, line))
            {
                var newPosition = new PiecePosition(column, line);
                if (IsOccupiedBySameColorPiece(board, newPosition))
                {
                    break;
                }
                positions.Add(newPosition);
                if (IsOccupiedByOtherColorPiece(board, newPosition))
                {
                    break;
                }
                line++;
                column++;
            }
            line = position.Line - 1;
            column = (char)(position.Column - 1);
            while (IsInBoard(column, line))
            {
                var newPosition = new PiecePosition(column, line);
                if (IsOccupiedBySameColorPiece(board, newPosition))
                {
                    break;
                }
                positions.Add(newPosition);
                if (IsOccupiedByOtherColorPiece(board, newPosition))
                {
                    break;
                }
                line--;
                column--;
            }

            line = position.Line - 1;
            column = (char)(position.Column + 1);
            while (IsInBoard(column, line))
            {
                var newPosition = new PiecePosition(column, line);
                if (IsOccupiedBySameColorPiece(board, newPosition))
                {
                    break;
                }
                positions.Add(newPosition);
                if (IsOccupiedByOtherColorPiece(board, newPosition))
                {
                    break;
                }
                line--;
                column++;
            }
            line = position.Line + 1;
            column = (char)(position.Column - 1);
            while (IsInBoard(column, line))
            {
                var newPosition = new PiecePosition(column, line);
                if (IsOccupiedBySameColorPiece(board, newPosition))
                {
                    break;
                }
                positions.Add(newPosition);
                if (IsOccupiedByOtherColorPiece(board, newPosition))
                {
                    break;
                }
                line++;
                column--;
            }
            return positions;
        }
    }
}