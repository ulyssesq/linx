using Algorithm.Logic.Domain;
using Algorithm.Logic.Interfaces;
using System.Collections.Generic;

namespace Algorithm.Logic.Services
{
    public class PositionService : IPositionService
    {
        public DronePosition GetPosition(List<IDroneCommand> droneCommands)
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
