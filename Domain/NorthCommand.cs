namespace Algorithm.Logic.Domain
{
    public class NorthCommand : BaseCommand
    {
        public NorthCommand(string input) : base(input)
        {
            Type = Enum.CommandType.N;
        }

        public override DroneMove GetMove() => new NorthMove(Quantity);
    }
}
