using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Teamwork_OOP.GameObjects.Map.Tiles
{
    public class Tile 
    {
        private bool isSteppable;
        private int stepBonus;
        private string type;
        private Vector2 position;

        public Tile(string type, Vector2 position)
        {
            IsSteppable = true;
            this.Type = type;
            this.Position = position;
            //TODO position could be derived from tile positon in array 
        }

        public Vector2 Position { get; set; }

        public bool IsSteppable { get; set; }

        public int StepBonus { get; set; }

        public string Type{ get; set; }


        
    }
}