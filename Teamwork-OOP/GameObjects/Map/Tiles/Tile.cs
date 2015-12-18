using Microsoft.Xna.Framework;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.GameObjects.Map.Tiles
{
    public class Tile : ITile
    {
        private bool isSteppable;
        private string type;
        private Vector2 position;

        public Tile(string type,bool isSteppable, Vector2 position)
        {
            IsSteppable = isSteppable;
            this.Type = type;
            this.Position = position;
            //TODO position could be derived from tile positon in array 
        }

        public Vector2 Position { get; set; }

        public bool IsSteppable { get; set; }

        public string Type{ get; set; }
        
    }
}