using Algorithm.Logic.Domain;
using Algorithm.Logic.Interfaces;
using System;
using System.Linq;

namespace Algorithm.Logic.Factory
{
    public static class CommandFactory
    {
        public static IDroneCommand GetInstance(string input)
        {
            switch (input.First())
            {
                case 'N': return new NorthCommand(input); 
                case 'S': return new SouthCommand(input);
                case 'L': return new EastCommand(input);
                case 'O': return new WestCommand(input);
                case 'X': return new CancelCommand(input);
            }

            throw new ArgumentException("Invalid input");
        }
    }
}
