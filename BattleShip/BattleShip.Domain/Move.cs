using System;
using System.Drawing;

namespace BattleShip.Domain
{
    public class Move : IEquatable<Move>
    {
        public int XPosition;
        public int YPosition;

        public Move(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }

        public bool Equals(Move other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return XPosition == other.XPosition && YPosition == other.YPosition;
        }
    }
}
