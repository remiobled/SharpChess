using ChessEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTest
{
    [TestClass]
    public class KnightTest
    {
        private IPlayer _whitePlayer = new LocalPlayer(PieceColor.White, (x, y) => { });
        private IPlayer _blackPlayer = new LocalPlayer(PieceColor.Black, (x, y) => { });

        [TestMethod]
        public void KnightMoves()
        {
            var board = BoardGenerator.GetInitialBoard();
            var position1 = new PiecePosition('B', 1);
            var position2 = new PiecePosition('C', 3);
            var position3 = new PiecePosition('B', 5);
            var position4 = new PiecePosition('C', 7);

            Assert.IsTrue(board.Move(_whitePlayer, position1, position2));
            Assert.IsTrue(board.Move(_whitePlayer, position2, position3));
            Assert.IsTrue(board.Move(_whitePlayer, position3, position4));
        }

        [TestMethod]
        public void KnightImpossibleMoves()
        {
            var board = BoardGenerator.GetInitialBoard();
            var position1 = new PiecePosition('B', 1);
            var position2 = new PiecePosition('B', 3);
            var position3 = new PiecePosition('A', 2);
            var position4 = new PiecePosition('D', 5);

            Assert.IsFalse(board.Move(_whitePlayer, position1, position2));
            Assert.IsFalse(board.Move(_whitePlayer, position1, position3));
            Assert.IsFalse(board.Move(_whitePlayer, position1, position4));
        }
    }
}