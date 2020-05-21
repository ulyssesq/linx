using System;
using System.Linq;

namespace Algorithm.Logic
{
    public class DroneCommand
    {
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

        public DroneMove GetMove()
        {
            if (Type == CommandType.N)
            {
                return new NorthMove(Quantity);
            }

            if (Type == CommandType.S)
            {
                return new SouthMove(Quantity);
            }

            if (Type == CommandType.L)
            {
                return new EastMove(Quantity);
            }

            if (Type == CommandType.O)
            {
                return new WestMove(Quantity);
            }

            return new NoMove();
        }
    }
}
