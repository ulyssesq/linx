using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic.Domain
{
    public abstract class BaseCommand
    {
        public decimal Quantity { get; }

        public BaseCommand(decimal quantity)
        {
            Quantity = quantity;
        }
    }
}
