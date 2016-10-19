namespace Game15
{
    internal sealed class GameHistoryRecord
    {
        private readonly int value;
        private readonly Location valueLocation;
        private readonly Location zeroLocation;

        public GameHistoryRecord(int value, Location valueLocation, Location zeroLocation)
        {
            this.value = value;
            this.valueLocation = valueLocation;
            this.zeroLocation = zeroLocation;
        }

        public int Value
        {
            get { return this.value; }
        }

        public Location ValueLocation
        {
            get { return this.valueLocation; }
        }

        public Location ZeroLocation
        {
            get { return this.zeroLocation; }
        }
    }
}
