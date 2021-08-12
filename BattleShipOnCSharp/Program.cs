using System;

namespace BattleShipOnCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start!"); // << std::flush;
            Game game = new Game();
            game.Setup();
            game.Print();

            bool isEnd;
            do
            {
                int x, y;
                Console.WriteLine("Player #" + game.WhoseMove + 1); // ". Make a guess: ");
                x = Convert.ToInt32(Console.ReadLine());
                y = Convert.ToInt32(Console.ReadLine());

                if (x < 1 || x > 10)
                {
                    Console.WriteLine("Enter x between 1 and 10.");
                }
                if (y < 1 || y > 10)
                {
                    Console.WriteLine("Enter y between 1 and 10.");
                }

                isEnd = game.MakeMove(x - 1, y - 1);
                game.Print();

            } while (!isEnd);
            Console.WriteLine("End!!!");
            Console.WriteLine("Player #" + (game.WhoseMove + 1) + " has won. Congrats!");
        }
    }
}