namespace Algorithm.Logic.Domain
{
    public class DroneMove
    {
        public const int MAXMOVIMENT = int.MaxValue; // 2147483647
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public DroneMove(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public bool IsValid() => X <= MAXMOVIMENT && Y <= MAXMOVIMENT;
    }
}
