namespace BattleShip.Console
{
    class Position
    {
		public int XPosition;
		public int YPosition;
		public Direction direction;

        public Position()
        {
            XPosition = 0;
            YPosition = 0;
            direction = Direction.Down;
        }
		public Position(int x, int y, Direction drt)
        {
            XPosition = x;
            YPosition = y;
            direction = drt;
        }
	}
}
