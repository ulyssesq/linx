namespace Algorithm.Logic.Domain
{
    public class WestCommand : BaseCommand
    {
        public WestCommand(string input) : base(input)
        {
            Type = Enum.CommandType.O;
        }

        public override DroneMove GetMove() => new WestMove(Quantity);
    }
}
