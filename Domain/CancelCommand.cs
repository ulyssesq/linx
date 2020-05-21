namespace Algorithm.Logic.Domain
{
    public class CancelCommand : BaseCommand
    {
        public CancelCommand(string input) : base(input)
        {
            Type = Enum.CommandType.X;
        }

        public override DroneMove GetMove() => new NoMove();
    }
}
