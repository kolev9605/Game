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
            //TODO FIX MOVEMENT ( NEED MORE KPK)
            //TODO Character should implement Imovable (all imovables have vector2 position and method Move())
            

            if (state.IsKeyDown(Keys.Right))
            {
                if (!((int) this.Position.X + this.StepSize >= map.Tiles.GetLength(1)*50))
                {
                    int tempCol = (int)(this.Position.X + this.StepSize) / 50;
                    int tempRol = (int)(this.Position.Y) / 50;
                    if (map.CanStepOn(tempRol, tempCol))
                        this.IncrementX(this.StepSize);
                }
            }
            
            if (state.IsKeyDown(Keys.Down))
            {
                if (!((int) this.Position.Y + this.StepSize >= map.Tiles.GetLength(0)*50))
                {
                    int tempCol = (int)this.Position.X / 50;
                    int tempRol = (int)(this.Position.Y + this.StepSize) / 50;
                    if (map.CanStepOn(tempRol, tempCol))
                        this.IncrementY(this.StepSize);
                }
            }
            
            if (state.IsKeyDown(Keys.Left))
            {
                if (!((int) this.Position.X - this.StepSize < 0))
                {
                    int tempCol = (int)(this.Position.X - this.StepSize) / 50;
                    int tempRol = (int)(this.Position.Y) / 50;
                    if (map.CanStepOn(tempRol, tempCol))
                        this.IncrementX(-this.StepSize);
                }
            }

            if (state.IsKeyDown(Keys.Up))
            {
                if (!((int) this.Position.Y- this.StepSize <0))
                {
                    int tempCol = (int)this.Position.X / 50;
                    int tempRol = (int)(this.Position.Y - this.StepSize) / 50;
                    if (map.CanStepOn(tempRol, tempCol))
                        this.IncrementY(-this.StepSize);
                }
            }
        }
    }
}
