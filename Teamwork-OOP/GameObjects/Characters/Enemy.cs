using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Teamwork_OOP.GameObjects.Characters
{
    class Enemy : Character
    {
        private int stepSize;

        public Enemy(Texture2D texture, Vector2 possition) 
            : base(possition)
        {
            this.StepSize = 2;
        }

        protected Enemy(
            Texture2D texture,
            Vector2 possition,
            int healthPoints,
            int attackPoints,
            int defencePoints,
            int range)
            : base (texture, possition, healthPoints, attackPoints, defencePoints, range)
        {
        }

        public int StepSize
        {
            get { return this.stepSize; }
            private set { this.stepSize = value; }
        }

        public void Move(KeyboardState state, Map.Map map)
        {
            throw new NotImplementedException();
        }
    }
}
