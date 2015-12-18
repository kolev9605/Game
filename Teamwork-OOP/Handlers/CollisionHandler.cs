using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Teamwork_OOP.GameObjects.Characters;
using Teamwork_OOP.GameObjects.Map;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.InputHandler
{
    public static class CollisionHandler
    {
        public static bool IsTileSteppable(int tempTileRow, int tempTileCol, IMap map)
        {
            return map.Tiles[tempTileRow, tempTileCol].IsSteppable;
        }
    }
}