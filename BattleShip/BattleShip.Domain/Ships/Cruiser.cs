namespace BattleShip.Domain.Ships
{
    public class Cruiser : Ship
    {
        public Cruiser()
        {
            Size = 3;
            StartPoint = new Position();
        }
    }
}
