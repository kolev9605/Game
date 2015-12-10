using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Teamwork_OOP.InputHandler;
using Teamwork_OOP.GameObjects.Map;

namespace Teamwork_OOP.GameObjects.Characters
{
    class Player : Character
    {
        
        public int stepSize;
        public int StepSize { get; private set; }   
        public Player(Texture2D texture, Vector2 possition) 
            : base(texture, possition)
        {
            this.StepSize = 2;
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
