using ChessEngine;

namespace ChessTest
{
    public static class BoardGenerator
    {
        private static IPlayer _whitePlayer = new LocalPlayer(PieceColor.White, (x, y) => { });
        private static IPlayer _blackPlayer = new LocalPlayer(PieceColor.Black, (x, y) => { });

        /*8 ♖  ♘  ♗  ♕  ♔  ♗  ♘  ♖ 
          7 ♙  ♙  ♙  ♙  ♙  ♙  ♙  ♙ 
          6                        
          5                        
          4                        
          3                        
          2 ♙  ♙  ♙  ♙  ♙  ♙  ♙  ♙ 
          1 ♖  ♘  ♗  ♕  ♔  ♗  ♘  ♖ 
            A  B  C  D  E  F  G  H */
        public static Board GetInitialBoard()
        {
            return new Board(PieceColor.White, PieceColor.Black);
        }

      /*8 ♖  ♘  ♗  ♕  ♔  ♗  ♘  ♖ 
        7 ♙  ♙  ♙  ♙  ♙  ♙  ♙  ♙ 
        6    ♘                   
        5                        
        4                        
        3                        
        2 ♙  ♙  ♙  ♙  ♙  ♙  ♙  ♙ 
        1 ♖     ♗  ♕  ♔  ♗  ♘  ♖ 
          A  B  C  D  E  F  G  H */
        public static Board GetWithWhiteKnightInB6()
        {
            var board = GetInitialBoard();
            board.Move(_whitePlayer, new PiecePosition('B', 1), new PiecePosition('C', 3));
            board.Move(_whitePlayer, new PiecePosition('C', 3), new PiecePosition('D', 5));
            board.Move(_whitePlayer, new PiecePosition('D', 5), new PiecePosition('B', 6));
            return board;
        }
    }
}