using Algorithm.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic.Services
{
    public class PositionService : IPositionService
    {
        public DronePosition GetPosition(List<DroneCommand> droneCommands)
        {
            var dronePosition = new DronePosition();

            foreach (var command in droneCommands)
            {
                dronePosition.Update(command);
            }

            return dronePosition;
        }
    }
}
