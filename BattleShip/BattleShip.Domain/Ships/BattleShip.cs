namespace BattleShip.Domain.Ships
{
    public class BattleShip : Ship
    {
        public BattleShip()
        {
            Size = 4;
            StartPoint = new Position();
        }
    }
}
