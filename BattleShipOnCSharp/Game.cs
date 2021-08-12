using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipOnCSharp
{
    class Game
    {
        public int WhoseMove;
        private Field field1 = new Field();
        private Field field2 = new Field();
        private Result result;

        public Game() { result = Result.Untouched; } // ???

        public void Setup()
        {
            field1.AllocateShips();
            field2.AllocateShips();
            WhoseMove = ChooseWhoseMove();
        }
        public bool MakeMove(int x, int y)
        {
            switch (WhoseMove)
            {
                case 0:
                    {
                        result = field2.Shoot(x, y);
                        break;
                    }
                case 1:
                    {
                        result = field1.Shoot(x, y);
                        break;
                    }
                default:
                    break;
            }

            // field.IsEnd() -> return true;
            if (field1.IsEnd() || field2.IsEnd())
                return true;

            if (result == Result.Missed)
            {
                WhoseMove = WhoseMove == 0 ? 1 : 0;
            }

            return false;
        }
        public void Print()
        {
            //system("CLS");

            if (WhoseMove == 0)
                Print(field2);
            else
                Print(field1);
        }
        public void Print(Field field)
        {
            Console.WriteLine("------------");
            for (int y = 0; y < 10; y++)
            {
                Console.WriteLine("|");

                for (int x = 0; x < 10; x++)
                {
                    if (field.Intercepts(x, y))
                    {
                        Move move = new Move(x, y);
                        if (field.HasMove(ref move))
                        {
                            Console.WriteLine("1");
                        }
                        else
                        {
                            Console.WriteLine("O");
                        }
                    }
                    else
                    {
                        Move move = new Move(x, y);
                        if (field.HasMove(ref move))
                        {
                            Console.WriteLine("X");
                        }
                        else
                        {
                            Console.WriteLine(" ");
                        }
                    }
                }

                Console.WriteLine("|");
            }
        }

        public int ChooseWhoseMove()
        {
            var random = new Random();
            WhoseMove = random.Next(0, 2);

            Console.WriteLine("Player #" + (WhoseMove + 1) + " starts.");
            return WhoseMove;
        }
    }
}