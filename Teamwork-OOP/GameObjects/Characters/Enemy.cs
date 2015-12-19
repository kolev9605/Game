using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.GameObjects.Characters
{
    class Enemy : Character
    {

        public Enemy(string type, 
            Vector2 position, 
            int health,
            int attack, 
            int defense, 
            int range, 
            int stepSize,
            int textureHeight,
            int textureWidth)
            : base(type,position, health, attack, defense, range, stepSize,textureHeight,textureWidth)
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
