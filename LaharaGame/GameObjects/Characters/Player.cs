namespace LaharaGame.GameObjects.Characters
{
    using Interfaces;
    using Data;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public abstract class Player : Character
    {
        protected Player(
            string spriteTexturePath,
            string type,
            Vector2 position,
            int healthPoints,
            int attackPoints,
            int defendPoints,
            int range,
            int stepSize,
            int textureHeight,
            int textureWidth)
            : base(
                  spriteTexturePath,
                  type,
                  position, 
                  healthPoints, 
                  attackPoints, 
                  defendPoints, 
                  range, 
                  stepSize, 
                  textureHeight, 
                  textureWidth)
        {
            
        }

        public override void Act(KeyboardState state, IMap map, MonsterData data)
        {
            this.Move(state,map, data);
            this.Attack(state,map);
        }

        public override void Move(KeyboardState state, IMap map, MonsterData data)
        {
            if (state.IsKeyDown(Keys.Right))
            {
                base.MoveRight(this, map, data);
                this.IsMoving = true;
                this.PlayAnimation("runRight");
            }

            if (state.IsKeyDown(Keys.Left))
            {
                base.MoveLeft(this, map, data);
                this.IsMoving = true;
                this.PlayAnimation("runLeft");
            }
            if (state.IsKeyDown(Keys.Up))
            {
                base.MoveUp(this, map, data);
                this.IsMoving = true;
                this.PlayAnimation("runUp");
            }
            if (state.IsKeyDown(Keys.Down))
            {
                base.MoveDown(this, map, data);
                this.IsMoving = true;
                this.PlayAnimation("runDown");
            }


            //setting the state to idle if the player is not moving
            if (!this.IsMoving)
            {
                if (this.CurrentAnimation.Contains("Down"))
                {
                    PlayAnimation("idleDown");
                }
                if (this.CurrentAnimation.Contains("Up"))
                {
                    PlayAnimation("idleUp");
                }
                if (this.CurrentAnimation.Contains("Left"))
                {
                    PlayAnimation("idleLeft");
                }
                if (this.CurrentAnimation.Contains("Right"))
                {
                    PlayAnimation("idleRight");
                }
            }

            //at the end of every update setting isMoving to false
            this.IsMoving = false;
        }


    }
}