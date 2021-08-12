using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipOnCSharp
{
    class BattleShip : Ship
    {
        public BattleShip()
        {
            Size = 4;
            StartPoint = new Position();
        }
    }
}
