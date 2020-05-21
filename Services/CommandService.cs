using Algorithm.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithm.Logic.Services
{
    public class CommandService : ICommandService
    {
        private const string Pattern = @"S\d{0,10}|N\d{0,10}|L\d{0,10}|O\d{0,10}|X";
       
        public List<DroneCommand> GetCommands(string input)
        {
            List<DroneCommand> droneCommands = new List<DroneCommand>();
            MatchCollection matches = Regex.Matches(input, Pattern);

            foreach (Match match in matches)
            {
                string rawCommand = match.Value;
                var droneCommand = new DroneCommand(rawCommand);
                droneCommands.Add(droneCommand);
            }

            return droneCommands;
        }
    }
}
