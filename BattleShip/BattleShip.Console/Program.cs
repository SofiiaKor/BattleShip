using System;
using BattleShip.Domain;

namespace BattleShip.Console
{
    internal class Program
    {
        private static void Main()
        {
            var battleShipService = new BattleShipService();
            battleShipService.Start();
            battleShipService.Print();

            var end = false;
            while (!end)
            {
                end = battleShipService.MakeMove();
                battleShipService.Print();
            }

            battleShipService.End();
        }
    }
}