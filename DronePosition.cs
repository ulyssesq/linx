using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic
{
    public class DronePosition
    {
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
            var relativePosition = command.GetPosition();

            if (relativePosition.X > int.MaxValue || relativePosition.Y > int.MaxValue)
            {
                throw new Exception("Número maior que o permitido.");
            }

            X += relativePosition.X;
            Y += relativePosition.Y;

            if (X > int.MaxValue || Y > int.MaxValue)
            {
                throw new Exception("Overflow");
            }
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
