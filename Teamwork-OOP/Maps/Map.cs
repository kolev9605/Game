using System;
using Microsoft.Xna.Framework.Graphics;
using Teamwork_OOP.Interfaces;
using Microsoft.Xna.Framework;

namespace Teamwork_OOP.Maps
{
    public class Map : Interfaces.IDrawable
    {
        Texture2D texture;
        Vector2 position;

        public Map()
        {
            this.Position = new Vector2(0, 0);
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }

            set
            {
                this.texture = value;
            }
        }
    }
}