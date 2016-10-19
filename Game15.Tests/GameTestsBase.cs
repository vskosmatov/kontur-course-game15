using System;

using NUnit.Framework;

namespace Game15.Tests
{
    public abstract class GameTestsBase
    {
        [Test]
        public void CreateGameTest()
        {
            Assert.DoesNotThrow(() => this.GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0));
        }

        [Test]
        public void CreateGameWithIncorrectChipsCount()
        {
            Assert.Throws<ArgumentException>(() => this.GetGame(1, 2, 3, 4, 5, 6, 7, 0));
        }

        [Test]
        public void CreateGameWithDuplicatesTest()
        {
            Assert.Throws<ArgumentException>(() => this.GetGame(1, 2, 3, 4, 5, 6, 7, 1, 0));
        }

        [Test]
        public void GetLocationTest()
        {
            var game = this.GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0);

            var expected = new Location(2, 0);
            var actual = game.GetLocation(3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByIndexTest()
        {
            var game = this.GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0);

            var expected = 4;
            var actual = game[0, 1];

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShiftLeftChipTest()
        {
            var game = this.GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0);
            var chip = 8;

            var newGame = game.Shift(chip);

            var expectedLocation = new Location(2, 2);
            var actualLocation = newGame.GetLocation(chip);

            Assert.AreEqual(expectedLocation, actualLocation);

            var actualValue = newGame[actualLocation.X, actualLocation.Y];

            Assert.AreEqual(chip, actualValue);
        }

        [Test]
        public void ShiftTopChipTest()
        {
            var game = this.GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0);
            var chip = 6;

            var newGame = game.Shift(chip);

            var expectedLocation = new Location(2, 2);
            var actualLocation = newGame.GetLocation(chip);

            Assert.AreEqual(expectedLocation, actualLocation);

            var actualValue = newGame[actualLocation.X, actualLocation.Y];

            Assert.AreEqual(chip, actualValue);
        }

        [Test]
        public void ShiftFartherChipTest()
        {
            var game = this.GetGame(1, 2, 3, 4, 5, 6, 7, 8, 0);
            var chip = 5;

            Assert.Throws<GameException>(() => game.Shift(chip));
        }

        protected abstract IGame GetGame(params int[] chips);
    }
}
