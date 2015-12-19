namespace LaharaGame.InputHandler
{
    using Interfaces;

    public static class CollisionHandler
    {
        public static bool IsTileSteppable(int tempTileRow, int tempTileCol, IMap map)
        {
            return map.Tiles[tempTileRow, tempTileCol].IsSteppable;
        }
    }
}