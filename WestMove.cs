using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic
{
    public class WestMove : DroneMove
    {
        public WestMove(decimal x) : base(-x, 0)
        {

        }
    }
}
