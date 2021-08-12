using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipOnCSharp
{
    class Cruiser : Ship
    {
        public Cruiser()
        {
            Size = 3;
            StartPoint = new Position();
        }
    }
}
