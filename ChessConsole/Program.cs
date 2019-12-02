using ChessEngine;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var player1 = new LocalPlayer(PieceColor.White, (b, p) => BoardRenderer.RenderBoard(b, p));
            var player2 = new LocalPlayer(PieceColor.Black, (b, p) => BoardRenderer.RenderBoard(b, p));

            var game = new ChessGame(player1, player2, (b,p)=> BoardRenderer.RenderBoard(b,p));
            game.StartGame();
        }
    }
}
