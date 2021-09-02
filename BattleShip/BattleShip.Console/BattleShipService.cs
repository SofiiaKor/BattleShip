using System;
using BattleShip.Domain;

namespace BattleShip.Console
{
    public class BattleShipService
    {
        private readonly Game _game = new Game();

        public void Start()
        {
            System.Console.WriteLine("Start!");

            _game.Setup();
            var whoseMove = _game.CurrentMove;
            System.Console.WriteLine("Player #" + (whoseMove + 1) + " starts.");
        }

        public void Print()
        {
            var currentField = _game.CurrentMove == 0 ? _game.Field1 : _game.Field2;
            Print(currentField);
        }

        private static void Print(Field field)
        {
            //System.Console.Clear();
            System.Console.WriteLine("------------");
            for (var y = 0; y < 10; y++)
            {
                System.Console.Write("|");

                for (var x = 0; x < 10; x++)
                {
                    if (field.Intercepts(x, y))
                    {
                        var move = new Move(x, y);
                        System.Console.Write(field.HasMove(move) ? "1" : "O");
                    }
                    else
                    {
                        var move = new Move(x, y);
                        System.Console.Write(field.HasMove(move) ? "X" : " ");
                    }
                }

                System.Console.WriteLine("|");
            }
        }

        public bool MakeMove()
        {
            var currentField = _game.CurrentMove == 0 ? _game.Field1 : _game.Field2;
            System.Console.WriteLine("Player #" + (_game.CurrentMove + 1)
                                                + ", make a guess: ");

            var x = Convert.ToInt32(System.Console.ReadLine());
            var y = Convert.ToInt32(System.Console.ReadLine());

            if (x < 1 || x > 10)
                System.Console.WriteLine("Enter x between 1 and 10.");
            if (y < 1 || y > 10)
                System.Console.WriteLine("Enter y between 1 and 10.");

            var isEnd = _game.MakeMove(x - 1, y - 1);

            var resOfMove = currentField.Shoot(x - 1, y - 1);

            switch (resOfMove)
            {
                case Result.Untouched:
                    System.Console.WriteLine("Do not repeat.");
                    break;
                case Result.Hit:
                    System.Console.WriteLine("You hit that!");
                    break;
                case Result.Missed:
                    System.Console.WriteLine("Oops, you've missed.");
                    break;
            }

            return isEnd;
        }

        public void End()
        {
            System.Console.WriteLine("End!!!");
            System.Console.WriteLine("Player #" + (_game.CurrentMove + 1)
                                                + " has won. Congrats!");
        }
    }
}