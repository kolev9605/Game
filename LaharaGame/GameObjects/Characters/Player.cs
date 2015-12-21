using System;
using System.Collections.Generic;

namespace LaharaGame.GameObjects.Characters
{
    using Interfaces;
    using Data;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Enums;

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
            int textureWidth,
            AttackState attackState = AttackState.notactivated)
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
                  textureWidth,
                  attackState)
        {
            
        }

        public override void Act(KeyboardState state, IMap map, List<Character> characters)
        {
            this.Move(state,map, characters);
            this.Attack(state,map, characters);
        }

        public override void Move(KeyboardState state, IMap map, List<Character> characters)
        {
            if (state.IsKeyDown(Keys.Right))
            {
                base.MoveRight(this, map, characters);
                this.IsMoving = true;
                this.PlayAnimation("runRight");
            }

            if (state.IsKeyDown(Keys.Left))
            {
                base.MoveLeft(this, map, characters);
                this.IsMoving = true;
                this.PlayAnimation("runLeft");
            }
            if (state.IsKeyDown(Keys.Up))
            {
                base.MoveUp(this, map, characters);
                this.IsMoving = true;
                this.PlayAnimation("runUp");
            }
            if (state.IsKeyDown(Keys.Down))
            {
                base.MoveDown(this, map, characters);
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

        public override void Attack(KeyboardState state, IMap map, List<Character> characters)//MonsterDataDict data
        {
            if (state.IsKeyDown(Keys.Space))
            {
                foreach (var enemy in characters)
                {
                    float deltaX = Math.Abs((enemy.Position.X+16) - (this.Position.X+22));
                    float deltaY = Math.Abs((enemy.Position.Y+16) - (this.Position.Y+22));
                    float distanceFromEnemy = (float)Math.Sqrt(deltaX*deltaX + deltaY*deltaY);
                    if (distanceFromEnemy<60)
                    {
                        enemy.HealthPoints = enemy.HealthPoints - this.AttackPoints;
                        enemy.AttackState = AttackState.Activated;
                    }
                }
            }
        }


    }
}