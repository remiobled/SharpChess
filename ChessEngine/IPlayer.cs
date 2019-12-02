namespace ChessEngine
{
    public interface IPlayer
    {
        PieceColor Color { get; }

        public void Play(Board board);
    }
}