using Algorithm.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Logic.Services
{
    public class SimplifyService : ISimplifyService
    {
        private List<IDroneCommand> DroneCommands;

        public SimplifyService(List<IDroneCommand> droneCommands)
        {
            if (droneCommands == null)
            {
                throw new ArgumentNullException("DroneCommand list is required.");
            }

            DroneCommands = droneCommands;
        }

        public List<IDroneCommand> Simplify()
        {
            ProcessXCommands();

            Filter();

            return DroneCommands;
        }

        private void ProcessXCommands()
        {
            int xCommands = 0;
            bool xFound = false;

            DroneCommands.Reverse(); // Inverte a lista para percorrer os X

            foreach (var command in DroneCommands)
            {
                if (command.IsCancel()) // se encontrou um comando X, sinaliza que encontrou e adiciona
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

            DroneCommands.Reverse(); // Retorna a lista na posição normal
        }

        private void Filter()
        {
            DroneCommands = DroneCommands
                .Where(c => !c.Removed && !c.IsCancel())
                .ToList();
        }
    }
}
