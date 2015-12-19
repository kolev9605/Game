namespace LaharaGame.GameObjects.Map.Tiles
{
    using Interfaces;
    using Microsoft.Xna.Framework;

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