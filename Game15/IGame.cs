namespace Game15
{
    public interface IGame
    {
        int this[int x, int y] { get; }

        int this[Location location] { get; }

        Location GetLocation(int value);

        IGame Shift(int value);
    }
}
