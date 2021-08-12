using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipOnCSharp
{
    class Destroyer : Ship
    {
        public Destroyer()
        {
            Size = 1;
            StartPoint = new Position();
        }
    }
}
