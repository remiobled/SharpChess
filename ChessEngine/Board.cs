using System;
using System.Collections.Generic;

namespace ChessEngine
{
    public class Board
    {
        private PieceColor _player1Color;
        private PieceColor _player2Color;

        private Piece[,] _pieces;

        public IPlayer Winner;

        public Board(PieceColor player1Color, PieceColor player2Color)
        {
            _player1Color = player1Color;
            _player2Color = player2Color;
            SetUpBoard();
        }

        private void RemovePiece(PiecePosition position)
        {
            _pieces[position.Column - 'A', position.Line - 1] = null;
        }

        public List<PiecePosition> GetPossiblePiecePositions(PiecePosition position)
        {
            var piece = GetPiece(position);
            return piece?.GetPossiblePiecePositions(position, this);
        }

        public bool IsPositionThreatened(PiecePosition position, PieceColor color)
        {
            PieceColor colorThreat;
            if (color == PieceColor.Black)
            {
                colorThreat = PieceColor.White;
            }
            else if (color == PieceColor.White)
            {
                colorThreat = PieceColor.Black;
            }
            else
            {
                throw new ArgumentException("Unknown piece color");
            }
            var allPositionsThreatened = new List<PiecePosition>();
            for(char col = 'A'; col <= 'H'; col++)
            {
                for (int line = 1; line <= 8; line++)
                {
                    var piecePosition = new PiecePosition(col, line);
                    var piece = GetPiece(piecePosition);
                    if(piece?.Color == colorThreat)
                    {
                        var possiblePiecePositions = GetPossiblePiecePositions(piecePosition);
                        if (possiblePiecePositions != null)
                        {
                            allPositionsThreatened.AddRange(possiblePiecePositions);
                        }
                    }
                }
            }
            return allPositionsThreatened.Contains(position);
        }

        public Piece GetPiece(PiecePosition position)
        {
            try
            {
                return _pieces[position.Column - 'A', position.Line - 1];
            }
            catch(Exception)
            {
                return null;
            }
            
        }

        private void SetPiece(PiecePosition position, Piece piece)
        {
            _pieces[position.Column - 'A', position.Line - 1] = piece;
        }

        public bool Move(IPlayer player, PiecePosition fromPosition, PiecePosition toPosition)
        {
            var pieceToMove = GetPiece(fromPosition);
            if(pieceToMove == null || pieceToMove.Color != player.Color || !pieceToMove.GetPossiblePiecePositions(fromPosition, this).Contains(toPosition))
            {
                return false;
            }
            else
            {
                if (Roque(fromPosition, toPosition))
                {
                    return true;
                }
                else
                {
                    pieceToMove.Move();
                    if(GetPiece(toPosition) is King)
                    {
                        Winner = player;
                    }
                    RemovePiece(toPosition);
                    SetPiece(toPosition, pieceToMove);
                    RemovePiece(fromPosition);
                    return true;
                }
            }
        }

        private bool Roque(PiecePosition fromPosition, PiecePosition toPosition)
        {
            var pieceToMove = GetPiece(fromPosition) as King;
            var pieceAtDestination = GetPiece(toPosition) as Rook;
            if (pieceToMove == null || pieceAtDestination == null)
            {
                return false;
            }
            var king = GetPiece(fromPosition);
            var rook = GetPiece(toPosition);
            SetPiece(toPosition, king);
            SetPiece(fromPosition, rook);
            return true;
        }

        private void SetUpBoard()
        {
            _pieces = new Piece[8, 8];
            SetPiece(new PiecePosition('A',1), new Rook(_player1Color));
            SetPiece(new PiecePosition('B',1), new Knight(_player1Color));
            SetPiece(new PiecePosition('C',1), new Bishop(_player1Color));
            SetPiece(new PiecePosition('D',1), new Queen(_player1Color));
            SetPiece(new PiecePosition('E',1), new King(_player1Color, 1));
            SetPiece(new PiecePosition('F',1), new Bishop(_player1Color));
            SetPiece(new PiecePosition('G',1), new Knight(_player1Color));
            SetPiece(new PiecePosition('H',1), new Rook(_player1Color));

            SetPiece(new PiecePosition('A',2), new Pawn(_player1Color, 1));
            SetPiece(new PiecePosition('B',2), new Pawn(_player1Color, 1));
            SetPiece(new PiecePosition('C',2), new Pawn(_player1Color, 1));
            SetPiece(new PiecePosition('D',2), new Pawn(_player1Color, 1));
            SetPiece(new PiecePosition('E',2), new Pawn(_player1Color, 1));
            SetPiece(new PiecePosition('F',2), new Pawn(_player1Color, 1));
            SetPiece(new PiecePosition('G',2), new Pawn(_player1Color, 1));
            SetPiece(new PiecePosition('H',2), new Pawn(_player1Color, 1));

            SetPiece(new PiecePosition('A',8), new Rook(_player2Color));
            SetPiece(new PiecePosition('B',8), new Knight(_player2Color));
            SetPiece(new PiecePosition('C',8), new Bishop(_player2Color));
            SetPiece(new PiecePosition('D',8), new Queen(_player2Color));
            SetPiece(new PiecePosition('E',8), new King(_player2Color, 8));
            SetPiece(new PiecePosition('F',8), new Bishop(_player2Color));
            SetPiece(new PiecePosition('G',8), new Knight(_player2Color));
            SetPiece(new PiecePosition('H',8), new Rook(_player2Color));

            SetPiece(new PiecePosition('A',7), new Pawn(_player2Color, -1));
            SetPiece(new PiecePosition('B',7), new Pawn(_player2Color, -1));
            SetPiece(new PiecePosition('C',7), new Pawn(_player2Color, -1));
            SetPiece(new PiecePosition('D',7), new Pawn(_player2Color, -1));
            SetPiece(new PiecePosition('E',7), new Pawn(_player2Color, -1));
            SetPiece(new PiecePosition('F',7), new Pawn(_player2Color, -1));
            SetPiece(new PiecePosition('G',7), new Pawn(_player2Color, -1));
            SetPiece(new PiecePosition('H',7), new Pawn(_player2Color, -1));
        }
    }
}