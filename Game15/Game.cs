using System;

namespace Game15
{
    public sealed class Game : IGame
    {
        private readonly int[,] field;
        private readonly Location[] map;

        public Game(params int[] chips)
        {
            if (chips == null)
            {
                throw new ArgumentNullException(nameof(chips));
            }

            if (chips.Length == 0)
            {
                throw new ArgumentException("Chips list can not be empty.", nameof(chips));
            }

            var sqrt = Math.Sqrt(chips.Length);

            if (Math.Round(sqrt) != sqrt)
            {
                throw new ArgumentException("Сhips must determine the square field.", nameof(chips));
            }

            var side = (int)sqrt;

            this.field = new int[side, side];
            this.map = new Location[chips.Length];

            for (var y = 0; y < side; y++)
            {
                for (var x = 0; x < side; x++)
                {
                    var chip = chips[y * side + x];

                    if (chip > chips.Length)
                    {
                        throw new ArgumentException($"Chips contains incorrect value {chip}.", nameof(chips));
                    }

                    if (x > 0 && y > 0 && (map[chip] != default(Location) || chip == this.field[0, 0]))
                    {
                        throw new ArgumentException("Chips contains duplicates.", nameof(chips));
                    }

                    this.field[x, y] = chip;
                    this.map[chip] = new Location(x, y);
                }
            }
        }

        public int this[Location location]
        {
            get { return this[location.X, location.Y]; }
        }

        public int this[int x, int y]
        {
            get { return this.field[x, y]; }
        }

        public Location GetLocation(int value)
        {
            if (value < 0 || value > this.map.Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.map[value];
        }

        public IGame Shift(int value)
        {
            if (value < 0 || value > this.map.Length - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            var valueLocation = this.map[value];
            var zeroLocation = this.map[0];

            if (!(valueLocation.X == zeroLocation.X && Math.Abs(valueLocation.Y - zeroLocation.Y) == 1) &&
                !(valueLocation.Y == zeroLocation.Y && Math.Abs(valueLocation.X - zeroLocation.X) == 1))
            {
                throw new GameException($"Near chip {value} is not empty place.");
            }

            this.map[0] = valueLocation;
            this.map[value] = zeroLocation;

            this.field[valueLocation.X, valueLocation.Y] = 0;
            this.field[zeroLocation.X, zeroLocation.Y] = value;

            return this;
        }
    }
}
