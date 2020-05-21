namespace Algorithm.Logic.Domain
{
    public class SouthMove : DroneMove
    {
        public SouthMove(decimal y) :
            base(0, -y)
        {

        }
    }
}
