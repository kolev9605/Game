using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Teamwork_OOP.InputHandler
{
    public static class TextureHandler
    {
        private static Dictionary<string, Texture2D> textureLibrary = new Dictionary<string, Texture2D>();

        public static void Load(ContentManager content)
        {
            textureLibrary.Add("grass_tile", content.Load<Texture2D>("grass_tile"));
            textureLibrary.Add("rock_tile", content.Load<Texture2D>("rock_tile"));
        }

        public static Texture2D GetTexture(string id)
        {
            return textureLibrary[id];
        }

    }
}