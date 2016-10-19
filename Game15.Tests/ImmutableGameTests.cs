using NUnit.Framework;

namespace Game15.Tests
{
    [TestFixture]
    public sealed class ImmutableGameTests : GameTestsBase
    {
        protected override IGame GetGame(params int[] chips)
        {
            return new ImmutableGame(chips);
        }
    }
}
