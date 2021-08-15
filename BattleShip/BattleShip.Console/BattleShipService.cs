using System;
using BattleShip.Domain;

namespace BattleShip.Console
{
    public class BattleShipService
    {
        public void Start()
        {
            System.Console.WriteLine("Start!"); // << std::flush;
            Game game = new Game();
            game.Setup();
            game.Print();

            bool isEnd;
            do
            {
                int x, y;
                System.Console.WriteLine("Player #" + game.WhoseMove + 1); // ". Make a guess: ");
                x = Convert.ToInt32(System.Console.ReadLine());
                y = Convert.ToInt32(System.Console.ReadLine());

                if (x < 1 || x > 10)
                {
                    System.Console.WriteLine("Enter x between 1 and 10.");
                }
                if (y < 1 || y > 10)
                {
                    System.Console.WriteLine("Enter y between 1 and 10.");
                }

                isEnd = game.MakeMove(x - 1, y - 1);
                game.Print();

            } while (!isEnd);
            System.Console.WriteLine("End!!!");
            System.Console.WriteLine("Player #" + (game.WhoseMove + 1) + " has won. Congrats!");
        }

        private void Print()
        {

        }
    }
}