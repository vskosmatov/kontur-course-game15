﻿using NUnit.Framework;

namespace Game15.Tests
{
    [TestFixture]
    public sealed class GameWithMemoryTests : GameTestsBase
    {
        protected override IGame GetGame(params int[] chips)
        {
            return new GameWithMemory(chips);
        }
    }
}
