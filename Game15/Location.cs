namespace Game15
{
    public struct Location
    {
        private readonly int x;
        private readonly int y;

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return this.x; }
        }

        public int Y
        {
            get { return this.y; }
        }

        public static bool operator == (Location location1, Location location2)
        {
            return location1.Equals(location2);
        }

        public static bool operator != (Location location1, Location location2)
        {
            return !(location1 == location2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Location))
            {
                return false;
            }

            return this.Equals((Location)obj);
        }

        public bool Equals(Location location)
        {
            return this.X == location.X && this.Y == location.Y;
        }

        public override int GetHashCode()
        {
            return (this.X * 2) ^ this.Y;
        }
    }
}