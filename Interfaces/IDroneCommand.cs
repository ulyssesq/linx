using Algorithm.Logic.Domain;
using Algorithm.Logic.Enum;

namespace Algorithm.Logic.Interfaces
{
    public interface IDroneCommand
    {
        bool Removed { get; }
        DroneMove GetMove();

        bool Is(CommandType type);

        bool IsCancel();
        void Remove();
    }
}
