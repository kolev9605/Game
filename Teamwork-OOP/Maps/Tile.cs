using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Teamwork_OOP.Maps
{
    public abstract class Tile
    {
        private const int width = 50;
        private const int height = 50;
        private readonly string path;

        public string Path { get;}

        //TODO: Implement effects on characters


        protected Tile(string path)
        {
            this.Texture2D = this.conte
        }

        public Texture2D Texture2D { get; set; }
    }
}