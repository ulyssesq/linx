using Algorithm.Logic.Domain;

namespace Algorithm.Logic.Interfaces
{
    public interface IDroneService
    {
        DronePosition GetPosition(string input);
    }
}
