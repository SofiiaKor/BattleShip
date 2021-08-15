using System;

namespace BattleShip.Domain
{
    public class Field
    {
        public Ship[] Ships;
        public Move[] Moves;
        public Field()
        {
            Ships = new Ship[10];
            Moves = new Move[0];
        }

        public void AllocateShips()
        {
            Ships[0] = AllocateShip(4);

            Ships[1] = AllocateShip(3);
            Ships[2] = AllocateShip(3);

            Ships[3] = AllocateShip(2);
            Ships[4] = AllocateShip(2);
            Ships[5] = AllocateShip(2);

            Ships[6] = AllocateShip(1);
            Ships[7] = AllocateShip(1);
            Ships[8] = AllocateShip(1);
            Ships[9] = AllocateShip(1);
        }
        private Ship AllocateShip(int length)
        {
            bool isAllowed;
            Random rand = new Random();
            int dir = rand.Next(0, 3);

            int x, y;
            Direction direction;
            do
            {
                x = rand.Next(1, 10);
                y = rand.Next(1, 10);
                direction = (Direction)dir;
                isAllowed = IsShipPositionAllowed(x, y, length, direction);
            } while (!isAllowed);

            Ship ship = new Ship(x, y, length, direction);
            return ship;
        }
        public bool IsShipPositionAllowed(int x, int y, int length, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (y - (length - 1) < 0)
                        return false;
                    break;
                case Direction.Down:
                    if (y + (length - 1) > 9)
                        return false;
                    break;
                case Direction.Left:
                    if (x - (length - 1) < 0)
                        return false;
                    break;
                case Direction.Right:
                    if (x + (length - 1) > 9)
                        return false;
                    break;
                default:
                    break;
            }

            var startX = x;
            var endX = x;
            var startY = y;
            var endY = y;

            switch (direction)
            {
                case Direction.Up:
                    startY = y - (length - 1);
                    endY = y;
                    break;
                case Direction.Down:
                    startY = y;
                    endY = y + (length - 1);
                    break;
                case Direction.Left:
                    startX = x - (length - 1);
                    endX = x;
                    break;
                case Direction.Right:
                    startX = x;
                    endX = x + (length - 1);
                    break;
                default:
                    break;
            }

            //for (int i = startX - 1; i <= endX + 1; i++)
            //{
            //    for (int j = startY - 1; j <= endY + 1; j++)
            //    {
            //        if (Intercepts(i, j))
            //        {
            //            return false;
            //        }
            //    }
            //}

            return true;
        }
        public bool Intercepts(int x, int y)
        {
            for (var i = 0; i < 10; i++)
            {
                if (Ships[i].Intercepts(x, y))
                {
                    return true;
                }
            }
            return false;
        }
        public Result Shoot(int x, int y)
        {
            Move move = new Move(x, y);

            if (HasMove(ref move))
            {
                System.Console.WriteLine("Do not repeat.");
                return Result.Untouched;
            }

            Add(ref move);

            for (int i = 0; i < 10; i++)
            {
                if (Ships[i].Intercepts(move.XPosition, move.YPosition))
                {
                    System.Console.WriteLine("You hit that!");
                    return Result.Hit;
                }
            }

            System.Console.WriteLine("Opps, you've missed.");
            return Result.Missed;
        }
        public void Add(ref Move move)
        {
            Move[] newArr = new Move[Moves.Length + 1];
            for (int i = 0; i < Moves.Length; i++)
            {
                newArr[i] = Moves[i];
            }
            newArr[Moves.Length] = move;
            Moves = newArr;
        }
        public bool HasMove(ref Move move)
        {
            for (int i = 0; i < Moves.Length; i++)
            {
                if (Moves[i].XPosition == move.XPosition && Moves[i].YPosition == move.YPosition)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsEnd()
        {
            int counter = 0;

            for (int i = 0; i < Moves.Length; i++)
            {
                if (Intercepts(Moves[i].XPosition, Moves[i].YPosition))
                {
                    counter++;
                }
            }

            if (counter == 20)
                return true;

            return false;
        }
    }
}
