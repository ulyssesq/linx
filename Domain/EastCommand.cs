namespace Algorithm.Logic.Domain
{
    public class EastCommand : BaseCommand
    {
        public EastCommand(string input) : base(input)
        {
            Type = Enum.CommandType.L;
        }

        public override DroneMove GetMove() => new EastMove(Quantity);
    }
}
