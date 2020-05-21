namespace Algorithm.Logic.Domain
{
    public class WestCommand : BaseDroneCommand
    {
        public WestCommand(string input) : base(input)
        {
            Type = Enum.CommandType.O;
        }

        public override DroneMove GetMove() => new WestMove(Quantity);
    }
}
