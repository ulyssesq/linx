using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithm.Logic
{
    public class DroneManager
    {
        public List<DroneCommand> DroneCommands { get; set; }

        public DroneManager(string input)
        {
            DroneCommands = GetCommands(input);
        }

        private List<DroneCommand> GetCommands(string input)
        {
            //string pattern = @"^(((N|S|L|O)\d{0,10})| X)+$";
            string pattern = @"S\d{0,10}|N\d{0,10}|L\d{0,10}|O\d{0,10}|X";
            MatchCollection matches = Regex.Matches(input, pattern);
            List<DroneCommand> rawCommands = new List<DroneCommand>();

            foreach (Match match in matches)
            {
                string rawCommand = match.Value;
                var droneCommand = new DroneCommand(rawCommand);
                rawCommands.Add(droneCommand);
            }

            return rawCommands;            
        }        
    }
}
