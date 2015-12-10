using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Teamwork_OOP.GameObjects.Characters;
using Teamwork_OOP.GameObjects.Map;

namespace Teamwork_OOP.InputHandler
{
    public static class CollisionHandler
    {
        public static bool IsTileSteppable(Vector2 position, Map map)
        {
            
            int tempTileCol = (int)position.X/50;
            int tempTileRow = (int)position.Y/50;
            //TODO----------------------------^ this needs to be a constant

            return map.CanStepOn(tempTileRow, tempTileCol);


        }
    }
}