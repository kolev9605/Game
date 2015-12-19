namespace LaharaGame.Interfaces
{
    using Microsoft.Xna.Framework;

    public  interface ITileFactory
    {
        ITile Make(string type, bool isSteppable, Vector2 position);
    }
}