using System.Collections.Generic;

namespace LaharaGame.GameObjects.Characters
{
    using Interfaces;
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Data;
    using Enums;

    class Enemy : Character
    {

        public Enemy(
            string spriteTexturePath, 
            string type,
            Vector2 position, 
            int health,
            int attack, 
            int defense, 
            int range, 
            int stepSize,
            int textureHeight,
            int textureWidth,
            AttackState attackState = AttackState.notactivated)
            : base(spriteTexturePath,
                  type, 
                  position, 
                  health, 
                  attack, 
                  defense, 
                  range, 
                  stepSize,
                  textureHeight,
                  textureWidth,
                  attackState)
        {
            
            PlayAnimation("idleDown");
        }
        
        public override void Act(KeyboardState state, IMap map, List<Character> characters)
        {
            throw new NotImplementedException();
        }

        public override void Move(KeyboardState state, IMap map, List<Character> characters)
        {
            
        }

        public override void Attack(KeyboardState state, IMap map, List<Character> characters)
        {
            if (this.AttackState==AttackState.Activated)
            {
                foreach (var enemy in characters)
                {
                    float deltaX = enemy.Position.X - this.Position.X;
                    float deltaY = enemy.Position.Y - this.Position.Y;
                    float distanceFromEnemy = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaX);
                    if (distanceFromEnemy < 10)
                    {
                        enemy.HealthPoints = enemy.HealthPoints - this.AttackPoints;
                        enemy.AttackState = AttackState.Activated;
                    }
                }
            }
        }
    }
}
