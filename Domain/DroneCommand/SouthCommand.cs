namespace Algorithm.Logic.Domain
{
    public class SouthCommand : BaseDroneCommand
    {
        public SouthCommand(string input) : base(input)
        {
            Type = Enum.CommandType.S;
        }

        public override DroneMove GetMove() => new SouthMove(Quantity);
    }
}
