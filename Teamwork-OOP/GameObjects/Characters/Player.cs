using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Teamwork_OOP.InputHandler;
using Teamwork_OOP.GameObjects.Map;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.GameObjects.Characters
{
    public abstract class Player : Character
    {
        protected Player(
            string type,
            Vector2 position,
            int healthPoints,
            int attackPoints,
            int defendPoints,
            int range,
            int stepSize,
            int textureHeight,
            int textureWidth)
            : base(type,position, healthPoints, attackPoints, defendPoints, range, stepSize, textureHeight, textureWidth)
        {
            
        }

        public override void Act(KeyboardState state, IMap map)
        {
            this.Move(state,map);
            this.Attack(state,map);
        }

        public override void Move(KeyboardState state, IMap map)
        {
            if (state.IsKeyDown(Keys.Right))
            {
                base.MoveRight(this, map);
                this.IsMoving = true;
                this.PlayAnimation("runRight");
            }

            if (state.IsKeyDown(Keys.Left))
            {
                base.MoveLeft(this, map);
                this.IsMoving = true;
                this.PlayAnimation("runLeft");
            }
            if (state.IsKeyDown(Keys.Up))
            {
                base.MoveUp(this, map);
                this.IsMoving = true;
                this.PlayAnimation("runUp");
            }
            if (state.IsKeyDown(Keys.Down))
            {
                base.MoveDown(this, map);
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