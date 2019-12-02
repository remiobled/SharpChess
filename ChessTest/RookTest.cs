using ChessEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTest
{
    [TestClass]
    public class RookTest
    {

        private IPlayer _whitePlayer = new LocalPlayer(PieceColor.White, (x, y) => { });
        private IPlayer _blackPlayer = new LocalPlayer(PieceColor.Black, (x, y) => { });

        [TestMethod]
        public void RookMoves()
        {
            var board = BoardGenerator.GetInitialBoard();
            board.Move(_whitePlayer, new PiecePosition('A', 2), new PiecePosition('A', 4));

            var position1 = new PiecePosition('A', 1);
            var position2 = new PiecePosition('A', 3);
            var position3 = new PiecePosition('H', 3);
            var position4 = new PiecePosition('H', 6);

            Assert.IsTrue(board.Move(_whitePlayer, position1, position2));
            Assert.IsTrue(board.Move(_whitePlayer, position2, position3));
            Assert.IsTrue(board.Move(_whitePlayer, position3, position4));
        }

        [TestMethod]
        public void RookImpossibleMoves()
        {
            var board = BoardGenerator.GetInitialBoard();
            board.Move(_whitePlayer, new PiecePosition('A', 2), new PiecePosition('A', 4));

            var position1 = new PiecePosition('A', 1);
            var position2 = new PiecePosition('A', 4);
            var position3 = new PiecePosition('A', 3);
            var position4 = new PiecePosition('H', 4);

            Assert.IsFalse(board.Move(_whitePlayer, position1, position2));
            Assert.IsTrue(board.Move(_whitePlayer, position1, position3));
            Assert.IsFalse(board.Move(_whitePlayer, position3, position4));
        }
    }
}
