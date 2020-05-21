namespace Algorithm.Logic.Domain
{
    public class NorthCommand : BaseDroneCommand
    {
        public NorthCommand(string input) : base(input)
        {
            Type = Enum.CommandType.N;
        }

        public override DroneMove GetMove() => new NorthMove(Quantity);
    }
}
