using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Teamwork_OOP.GameObjects.Characters
{
    class Enemy : Character
    {
        public Enemy(Texture2D texture, Vector2 possition) : base(texture, possition)
        {
        }
    }
}
