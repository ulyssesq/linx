using Algorithm.Logic.Domain;
using System.Collections.Generic;

namespace Algorithm.Logic.Interfaces
{
    public interface IPositionService
    {
        DronePosition GetPosition(List<IDroneCommand> droneCommands);
    }
}
