using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic
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

        public bool IsValid()
        {
            return X > MAXMOVIMENT || Y > MAXMOVIMENT;
        }
    }
}
