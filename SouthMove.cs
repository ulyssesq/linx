using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic
{
    public class SouthMove : DroneMove
    {
        public SouthMove(decimal y) :
            base(0, -y)
        {

        }
    }
}
