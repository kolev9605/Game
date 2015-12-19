namespace LaharaGame.GameObjects.Characters
{
    using Interfaces;
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

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
            int textureWidth)
            : base(spriteTexturePath,
                  type, 
                  position, 
                  health, 
                  attack, 
                  defense, 
                  range, 
                  stepSize,
                  textureHeight,
                  textureWidth)
        {
            
            PlayAnimation("idleDown");
        }
        
        public override void Act(KeyboardState state, IMap map)
        {
            throw new NotImplementedException();
        }

        public override void Move(KeyboardState state, IMap map)
        {
            
        }

        public override void Attack(KeyboardState state, IMap map)
        {
            throw new NotImplementedException();
        }
    }
}
