using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Teamwork_OOP.GameObjects.Characters;
using Teamwork_OOP.GameObjects.Map;

namespace Teamwork_OOP.InputHandler
{
    public static class CollisionHandler
    {
        public static bool IsTileSteppable(int tempTileRow, int tempTileCol, Map map)
        {
            return map.Tiles[tempTileRow, tempTileCol].IsSteppable;
        }
    }
}