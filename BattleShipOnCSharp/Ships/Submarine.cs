using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipOnCSharp
{
    class Submarine : Ship
    {
        public Submarine()
        {
            Size = 2;
            StartPoint = new Position();
        }
    }
}
