using ChessEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTest
{
    [TestClass]
    public class PawnTest
    {
        private IPlayer _whitePlayer = new LocalPlayer(PieceColor.White, (x, y) => { });
        private IPlayer _blackPlayer = new LocalPlayer(PieceColor.Black, (x, y) => { });

        [TestMethod]
        public void PawnFirstMoves1CellTest()
        {
            var board = BoardGenerator.GetInitialBoard();
            for(char col ='A'; col <='H'; col++)
            {
                var position1 = new PiecePosition(col, 2);
                var position2 = new PiecePosition(col, 3);
                var position3 = new PiecePosition(col, 4);
                Assert.IsTrue(board.Move(_whitePlayer, position1, position2));
                Assert.IsFalse(board.Move(_blackPlayer, position1, position2));
                Assert.IsTrue(board.Move(_whitePlayer, position2, position3));
            }

            for (char col = 'A'; col <= 'H'; col++)
            {
                var position1 = new PiecePosition(col, 7);
                var position2 = new PiecePosition(col, 6);
                var position3 = new PiecePosition(col, 4);
                Assert.IsFalse(board.Move(_whitePlayer, position1, position2));
                Assert.IsTrue(board.Move(_blackPlayer, position1, position2));
                Assert.IsFalse(board.Move(_blackPlayer, position2, position3));
            }
        }

        [TestMethod]
        public void PawnFirstMove2CellsTest()
        {
            var board = BoardGenerator.GetInitialBoard();
            for (char col = 'A'; col <= 'H'; col++)
            {
                var fromPosition = new PiecePosition(col, 2);
                var toPosition = new PiecePosition(col, 4);
                Assert.IsTrue(board.Move(_whitePlayer, fromPosition, toPosition));
                Assert.IsFalse(board.Move(_blackPlayer, fromPosition, toPosition));
            }

            for (char col = 'A'; col <= 'H'; col++)
            {
                var fromPosition = new PiecePosition(col, 7);
                var toPosition = new PiecePosition(col, 5);
                Assert.IsFalse(board.Move(_whitePlayer, fromPosition, toPosition));
                Assert.IsTrue(board.Move(_blackPlayer, fromPosition, toPosition));
            }
        }


        [TestMethod]
        public void PawnCrossMoveForbiddenTest()
        {
            var board = BoardGenerator.GetInitialBoard();
            var fromPosition = new PiecePosition('A', 7);
            var toPosition = new PiecePosition('B', 6);
            Assert.IsFalse(board.Move(_blackPlayer, fromPosition, toPosition));
        }

        [TestMethod]
        public void PawnCrossMoveToTakePieceAuthorizedTest()
        {
            var board = BoardGenerator.GetWithWhiteKnightInB6();
            var fromPosition = new PiecePosition('A', 7);
            var toPosition = new PiecePosition('B', 6);
            Assert.IsTrue(board.Move(_blackPlayer, fromPosition, toPosition));

            board = BoardGenerator.GetWithWhiteKnightInB6();
            fromPosition = new PiecePosition('C', 7);
            toPosition = new PiecePosition('B', 6);
            Assert.IsTrue(board.Move(_blackPlayer, fromPosition, toPosition));
        }

        [TestMethod]
        public void PawnStraightMoveToTakePieceForbiddenTest()
        {
            var board = BoardGenerator.GetWithWhiteKnightInB6();
            var fromPosition = new PiecePosition('B', 7);
            var toPosition = new PiecePosition('B', 6);
            Assert.IsFalse(board.Move(_blackPlayer, fromPosition, toPosition));
        }
    }
}
