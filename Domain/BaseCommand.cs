using Algorithm.Logic.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic.Domain
{
    public abstract class BaseCommand
    {
        public string RawCommand { get; set; }
        public decimal Quantity { get; }
        public bool Removed { get; protected set; }
        public CommandType Type { get; protected set; }

        public BaseCommand(string input)
        {
            RawCommand = input;
            Quantity = GetQuantity(input);
            Removed = false;
        }

        private decimal GetQuantity(string command)
        {
            if (command.Length == 1)
            {
                return 1;
            }

            decimal quantity;
            string number = command.Substring(1);
            bool valid = decimal.TryParse(number, out quantity);

            if (!valid)
            {
                throw new Exception($"Número (${number}) inválido.");
            }

            return Convert.ToInt32(quantity);
        }

        public override string ToString()
        {
            if (Quantity == 1)
            {
                return Type.ToString();
            }

            return $"{Type.ToString()}{Quantity.ToString()}";
        }

        public bool Is(CommandType type) => Type == type;

        public bool IsX() => Is(CommandType.X);        

        public abstract DroneMove GetMove();
    }
}
