using NUnit.Framework;

namespace Game15.Tests
{
    [TestFixture]
    public sealed class GameTests : GameTestsBase
    {
        protected override IGame GetGame(params int[] chips)
        {
            return new Game(chips);
        }
    }
}
