namespace BattleShip.Domain
{
    public class Ship
    {
        protected int Size;
        protected Position StartPoint;

        public Ship()
        {
            StartPoint = new Position();
            Size = 0;
        }

        public Ship(int x, int y, int size, Direction direction)
        {
            StartPoint = new Position(x, y, direction);
            Size = size;
        }

        public bool Intercepts(int x, int y)
        {
            if (StartPoint == null)
                return false;

            if (x.Equals(y))
                return true;

            switch (StartPoint.Direction)
            {
                case Direction.Down:
                    {
                        for (var i = 1; i < Size; i++)
                        {
                            if (x == StartPoint.X && y == StartPoint.Y + i)
                                return true;
                        }
                        break;
                    }
                case Direction.Up:
                    {
                        for (var i = 1; i < Size; i++)
                        {
                            if (x == StartPoint.X && y == StartPoint.Y - i)
                                return true;
                        }
                        break;
                    }
                case Direction.Left:
                    {
                        for (var i = 1; i < Size; i++)
                        {
                            if (x == StartPoint.X - i && y == StartPoint.Y)
                                return true;
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        for (var i = 1; i < Size; i++)
                        {
                            if (x == StartPoint.X + i && y == StartPoint.Y)
                                return true;
                        }
                        break;
                    }
            }
            return false;
        }
    }
}
