using System;

namespace Algorithm.Logic
{
    public class DronePosition
    {
        public const int MAXPOSITION = int.MaxValue; // 2147483647
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public DronePosition()
        {
            X = 0;
            Y = 0;
        }

        public DronePosition(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public void Update(DroneCommand command)
        {
            var droneMove = command.GetMove();

            if (droneMove.IsValid())
            {
                throw new Exception("Move overflow.");
            }

            X += droneMove.X;
            Y += droneMove.Y;

            if (IsValid())
            {
                throw new Exception("Position Overflow");
            }
        }

        private bool IsValid()
        {
            return X > MAXPOSITION || Y > MAXPOSITION;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public static DronePosition InvalidPosition
        {
            get
            {
                return new DronePosition(999, 999);
            }
        }
    }
}
