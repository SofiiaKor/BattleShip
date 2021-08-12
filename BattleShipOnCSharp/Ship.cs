using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipOnCSharp
{
    class Ship
    {
        protected int Size;
        protected Position StartPoint;
        public Ship()
        {
            StartPoint = new Position();
            Size = 0;
        }

        public Ship(int x, int y, int size, Direction drt)
        {
            StartPoint = new Position(x, y, drt);
            Size = size;
        }

        public int GetSize() { return Size; }
        public Position GetStartPoint() { return StartPoint; }
        public bool Intercepts(int x, int y)
        {
            if (StartPoint == null)
                return false;

            if (x == StartPoint.XPosition && y == StartPoint.YPosition)
                return true;

            switch (StartPoint.direction)
            {
                case Direction.Down:
                    {
                        for (int i = 1; i < Size; i++)
                        {
                            if (x == StartPoint.XPosition && y == StartPoint.YPosition + i)
                                return true;
                        }
                        break;
                    }
                case Direction.Up:
                    {
                        for (int i = 1; i < Size; i++)
                        {
                            if (x == StartPoint.XPosition && y == StartPoint.YPosition - i)
                                return true;
                        }
                        break;
                    }
                case Direction.Left:
                    {
                        for (int i = 1; i < Size; i++)
                        {
                            if (x == StartPoint.XPosition - i && y == StartPoint.YPosition)
                                return true;
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        for (int i = 1; i < Size; i++)
                        {
                            if (x == StartPoint.XPosition + i && y == StartPoint.YPosition)
                                return true;
                        }
                        break;
                    }
                default:
                    break;
            }
            return false;
        }
    }
}
