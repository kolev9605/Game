namespace LaharaGame.Factories
{
    using GameObjects.Map.Tiles;
    using Interfaces;
    using Microsoft.Xna.Framework;

    public class TileFactory : ITileFactory
    {
        public ITile Make(string type, bool isSteppable, Vector2 position)
        {
            return new Tile(type, isSteppable, position);
        }
    }
}
