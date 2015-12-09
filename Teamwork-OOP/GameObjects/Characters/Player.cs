using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        public void Move(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Right))
                this.IncrementX(this.StepSize);
            if (state.IsKeyDown(Keys.Down))
                this.IncrementY(this.StepSize);
            if (state.IsKeyDown(Keys.Left))
                this.IncrementX(-this.StepSize);
            if (state.IsKeyDown(Keys.Up))
                this.IncrementY(-this.StepSize);
        }
        
    }
}
