using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Teamwork_OOP.GameObjects.Characters
{
    class Player : Character
    {
        private int stepSize;

         
        public Player(Texture2D texture, Vector2 possition) 
            : base(texture, possition)
        {
            this.StepSize = 2;
        }

        protected Player(
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
            //TODO FIX MOVING -> it has bugs now
            //TODO Character should implement Imovable (all imovables have vector2 position and method Move())
            //if (CollisionHandler.IsTileSteppable(new Vector2(this.Position.X + this.stepSize, this.Position.Y), map))
            //{
            //    this.IncrementX(this.StepSize);
            //}
            //else this.IncrementX(-this.StepSize);

            if (state.IsKeyDown(Keys.Right))
            {
                int tempCol = (int)(this.Position.X + this.StepSize) / 50;
                int tempRol = (int)(this.Position.Y) / 50;
                if (map.CanStepOn(tempRol, tempCol))
                    this.IncrementX(this.StepSize);
                //else this.IncrementX(-this.StepSize*2);
            }

            //
            if (state.IsKeyDown(Keys.Down))
            {
                int tempCol = (int)this.Position.X/50;
                int tempRol = (int)(this.Position.Y+this.StepSize)/50;
                if (map.CanStepOn(tempRol,tempCol))
                    this.IncrementY(this.StepSize);
                //else this.IncrementY(-this.StepSize*2);
            }


            //
            if (state.IsKeyDown(Keys.Left))
            {
                int tempCol = (int)(this.Position.X - this.StepSize) / 50;
                int tempRol = (int)(this.Position.Y) / 50;
                if (map.CanStepOn(tempRol, tempCol))
                    this.IncrementX(-this.StepSize);
                //else this.IncrementX(this.StepSize*2);
            }

            if (state.IsKeyDown(Keys.Up))
            {
                int tempCol = (int)this.Position.X / 50;
                int tempRol = (int)(this.Position.Y - this.StepSize) / 50;
                if (map.CanStepOn(tempRol, tempCol))
                    this.IncrementY(-this.StepSize);
                //else this.IncrementY(this.StepSize*2);
            }

        }
    }
}
