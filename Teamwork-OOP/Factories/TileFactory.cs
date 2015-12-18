using System.Management.Instrumentation;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using Teamwork_OOP.GameObjects.Map.Tiles;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.Factories
{
    public class TileFactory : ITileFactory
    {
        public ITile Make(string type, bool isSteppable, Vector2 position)
        {
            return new Tile(type, isSteppable, position);
        }
        
    }
}
