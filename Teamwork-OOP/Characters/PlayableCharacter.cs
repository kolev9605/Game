using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.Characters
{
    class PlayableCharacter
    {
        private const int MovementSpeed = 1;

        private Vector2 position;
        private Texture2D texture;

        public PlayableCharacter()
        {
            this.position = new Vector2(0, 0);
        }

        public Texture2D Texture
        {
            get { return this.texture; }
            set { this.texture = value; }
        }

        public void MoveRight()
        {
            this.position.X += MovementSpeed;
        }

        public void MoveDown()
        {
            this.position.Y += MovementSpeed;
        }

        public void MoveLeft()
        {
            this.position.X -= MovementSpeed;
        }

        public void MoveUp()
        {
            this.position.Y -= MovementSpeed;
        }
    }
}
