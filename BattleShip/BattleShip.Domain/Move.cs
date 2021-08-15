namespace BattleShip.Domain
{
    public class Move
    {
    public int XPosition;
    public int YPosition;

    public Move(int x, int y) { XPosition = x; YPosition = y; }
    public Move() { XPosition = 0; YPosition = 0; }
    }
}
