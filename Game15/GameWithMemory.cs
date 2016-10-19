using System;

namespace Game15
{
    public sealed class GameWithMemory : IGame
    {
        private readonly GameHistoryRecord record;
        private readonly IGame baseGame;

        public GameWithMemory(params int[] chips)
        {
            this.baseGame = new ImmutableGame(chips);
        }

        private GameWithMemory(GameHistoryRecord record, IGame baseGame)
        {
            this.record = record;
            this.baseGame = baseGame;
        }

        public int this[int x, int y]
        {
            get
            {
                var location = new Location(x, y);

                return this[location];
            }
        }

        public int this[Location location]
        {
            get
            {
                if (this.record != null)
                {
                    if (this.record.ValueLocation == location)
                    {
                        return this.record.Value;
                    }

                    if (this.record.ZeroLocation == location)
                    {
                        return 0;
                    }
                }

                return this.baseGame[location];
            }
        }

        public Location GetLocation(int value)
        {
            if (this.record != null)
            {
                if (value == this.record.Value)
                {
                    return this.record.ValueLocation;
                }

                if (value == 0)
                {
                    return this.record.ZeroLocation;
                }
            }

            return this.baseGame.GetLocation(value);
        }

        public IGame Shift(int value)
        {
            var valueLocation = this.GetLocation(value);
            var zeroLocation = this.GetLocation(0);

            if (!(valueLocation.X == zeroLocation.X && Math.Abs(valueLocation.Y - zeroLocation.Y) == 1) &&
                !(valueLocation.Y == zeroLocation.Y && Math.Abs(valueLocation.X - zeroLocation.X) == 1))
            {
                throw new GameException($"Near chip {value} is not empty place.");
            }

            var newRecord = new GameHistoryRecord(value, zeroLocation, valueLocation);

            return new GameWithMemory(newRecord, this);
        }
    }
}
