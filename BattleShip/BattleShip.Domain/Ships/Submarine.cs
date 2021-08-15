namespace BattleShip.Domain.Ships
{
    public class Submarine : Ship
    {
        public Submarine()
        {
            Size = 2;
            StartPoint = new Position();
        }
    }
}
