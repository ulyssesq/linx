using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic
{
    public class DroneCommand
    {
        private const int MAXQUANTITY = 2147483647;
        public CommandType Type { get; set; }
        public decimal Quantity { get; set; }
        public string RawCommand { get; set; }
        public bool Removed { get; set; }

        public DroneCommand(string command)
        {
            RawCommand = command;
            Type = GetCommandType(command);
            Quantity = GetQuantity(command);
            Removed = false;
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

        private decimal GetQuantity(string command)
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

            return Convert.ToInt32(quantity);
        }

        public void Remove()
        {
            Removed = true;
        }

        public bool Is(CommandType type)
        {
            return Type == type;
        }

        public bool IsX()
        {
            return Is(CommandType.X);
        }

        public override string ToString()
        {
            if (Quantity == 1)
            {
                return Type.ToString();
            }

            return $"{Type.ToString()}{Quantity.ToString()}";
        }

        public DronePosition GetPosition()
        {
            if (Type == CommandType.N)
            {
                return new DronePosition(0, Quantity);
            }

            if (Type == CommandType.S)
            {
                return new DronePosition(0, -Quantity);
            }

            if (Type == CommandType.L)
            {
                return new DronePosition(Quantity, 0);
            }

            if (Type == CommandType.O)
            {
                return new DronePosition(-Quantity, 0);
            }

            return new DronePosition();
        }
    }
}
