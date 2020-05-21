using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Algorithm.Logic
{
    public class DroneManager
    {
        private const string Pattern = @"S\d{0,10}|N\d{0,10}|L\d{0,10}|O\d{0,10}|X";
        private const string FullPattern = @"^(((S\d{0,10})|(N\d{0,10})|(L\d{0,10})|(O\d{0,10})|X)+)$";
        public List<DroneCommand> DroneCommands { get; private set; }
        public string RawInput { get; }
        public DronePosition Position { get; private set; }
        public bool IsValid { 
            get
            {
                return Validate();
            } 
        }


        public DroneManager(string input)
        {
            RawInput = input;
            Init();
        }

        private void Init()
        {
            try
            {
                if (!IsValid)
                {
                    throw new Exception("Entrada inválida");
                }

                DroneCommands = new List<DroneCommand>();
                Position = new DronePosition();
                ProcessInput();
                ProcessXCommands();
                ProcessDronePosition();
            }
            catch 
            {
                Position = DronePosition.InvalidPosition;
            }
        }

        private void ProcessInput()
        {
            MatchCollection matches = Regex.Matches(RawInput, Pattern);

            foreach (Match match in matches)
            {
                string rawCommand = match.Value;
                var droneCommand = new DroneCommand(rawCommand);
                DroneCommands.Add(droneCommand);
            }
        }

        private void ProcessXCommands()
        {
            int xCommands = 0;
            bool xFound = false;

            DroneCommands.Reverse(); // Inverte a lista para percorrer os X

            foreach (var command in DroneCommands)
            {
                if (command.IsX()) // se encontrou um comando X, sinaliza que encontrou e adiciona
                {
                    if (xFound) // Se já tinha encontrado um comando X anteriormente, então acumula a quantidade de X para depois remover os outros comandos
                    {
                        xCommands++; // Acumula quantidade de X
                    }
                    else // Se o comando anterior não foi um X, então não deve acumular
                    {
                        xCommands = 1;
                    }

                    xFound = true; // Sinaliza que um comando X foi encontrado
                    continue; // Vai para o próximo comando
                }

                if (xCommands > 0)
                {
                    xFound = false; // Sinaliza que o comando agora não é um X para ele parar de acumular
                    command.Remove();
                    xCommands--; // Subtrai a quantidade de comandos que devem ser removidos
                }              
            }

            DroneCommands.Reverse(); // Vou a lista a posição normal
        }

        public List<DroneCommand> GetSimplifiedCommands()
        {
            return DroneCommands
                .Where(c => !c.Removed && !c.IsX())
                .ToList();
        }

        public string GetSimplifiedInput()
        {
            StringBuilder builder = new StringBuilder();
            var commands = GetSimplifiedCommands();

            foreach (var command in commands)
            {
                builder.Append(command.ToString());
            }

            return builder.ToString();
        }

        private void ProcessDronePosition()
        {
            foreach (var command in GetSimplifiedCommands())
            {
                Position.Update(command);
            }
        }

        private bool Validate()
        {
            if (String.IsNullOrWhiteSpace(RawInput))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(RawInput, FullPattern);
            }
        }
    }
}
