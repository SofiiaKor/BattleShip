using System;

namespace BattleShip.Domain
{
    public class Game
    {
        public int CurrentMove;
        public Field Field1 = new Field();
        public Field Field2 = new Field();
        public Result Result;

        public void Setup()
        {
            Field1.AllocateShips();
            Field2.AllocateShips();

            var random = new Random();
            CurrentMove = random.Next(0, 2);
        }

        public bool MakeMove(int x, int y)
        {
            var field = CurrentMove == 0 ? Field2 : Field1;
            Result = field.Shoot(x, y);

            if (Field1.IsEnd() || Field2.IsEnd())
                return true;

            if (Result == Result.Missed || Result == Result.Untouched)
            {
                CurrentMove = CurrentMove == 0 ? 1 : 0;
            }

            return false;
        }
    }
}