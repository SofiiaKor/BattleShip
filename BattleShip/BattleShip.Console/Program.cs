using System;
using BattleShip.Domain;

namespace BattleShip.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var battleShipService = new BattleShipService();
            battleShipService.Start();
        }
    }
}