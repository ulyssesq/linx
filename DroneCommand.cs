using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic
{
    public class DroneCommand
    {
        private const int MAXQUANTITY = 2147483647;
        public CommandType Type { get; set; }
        public int Quantity { get; set; }
        public string RawCommand { get; set; }

        public DroneCommand(string command)
        {
            RawCommand = command;
            Type = GetCommandType(command);
            Quantity = GetQuantity(command);
        }

        private CommandType GetCommandType(string command)
        {
            switch (command.First())
            {
                case 'N':
                    return CommandType.N;
                case 'S':
                    return CommandType.S;
                case 'L':
                    return CommandType.L;
                case 'O':
                    return CommandType.O;
                case 'X':
                    return CommandType.X;
            }

            throw new Exception("Invalid Command");
        }

        private int GetQuantity(string command)
        {
            if (command.Length == 1)
            {
                return 1;
            }

            decimal quantity;
            string number = command.Substring(1);
            bool valid = decimal.TryParse(number, out quantity);

            if (!valid )
            {
                throw new Exception($"Número (${number}) inválido.");
            }
                    
            if (quantity > MAXQUANTITY)
            {
                throw new OverflowException($"Número (${number}) maior que o permitido.");
            }

            return Convert.ToInt32(quantity);
        }
    }
}
