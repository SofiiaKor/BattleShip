using System;
using System.Linq;

namespace BattleShip.Domain
{
    public class Field
    {
        public Ship[] Ships;
        public Move[] Moves;

        public Field()
        {
            Ships = new Ship[10];
            //foreach (var variable in Ships)
            //variable = new Ship();

            for (var i = 0; i < Ships.Length; i++)
            {
                Ships[i] = new Ship();
            }
            // Moves should repeat at most two times
            Moves = Array.Empty<Move>();
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
            var random = new Random();
            var direction = (Direction)random.Next(0, 3);

            while (true)
            {
                var x = random.Next(1, 10);
                var y = random.Next(1, 10);

                var isAllowed = IsShipPositionAllowed(x, y, length, direction);
                if (isAllowed)
                    return new Ship(x, y, length, direction);
            }
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
            }

            for (var i = startX - 1; i <= endX + 1; i++)
            {
                for (var j = startY - 1; j <= endY + 1; j++)
                {
                    if (Intercepts(i, j))
                    {
                        return false;
                    }
                }
            }

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
            var move = new Move(x, y);
            if (HasMove(move))
            {
                return Result.Untouched;
            }

            Add(move);

            for (var i = 0; i < 10; i++)
            {
                if (Ships[i].Intercepts(move.XPosition, move.YPosition))
                {
                    return Result.Hit;
                }
            }

            return Result.Missed;
        }

        public void Add(Move move)
        {
            var array = new Move[Moves.Length + 1];
            for (var i = 0; i < Moves.Length; i++)
            {
                array[i] = Moves[i];
            }
            array[Moves.Length] = move;

            Moves = array;
        }

        public bool HasMove(Move move)
        {
            return Moves.Any(existingMove => existingMove.Equals(move));
        }

        public bool IsEnd()
        {
            var counter = Moves.Count(move => Intercepts(move.XPosition, move.YPosition));
            return counter >= 20;
        }
    }
}
