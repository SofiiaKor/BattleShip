namespace BattleShip.Domain
{
    public class Position
    {
        public int X;
        public int Y;
        public Direction Direction;

        public Position()
        {
            X = 0;
            Y = 0;
            Direction = Direction.Down;
        }
        public Position(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
