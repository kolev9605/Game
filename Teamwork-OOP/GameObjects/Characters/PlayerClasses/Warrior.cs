using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.GameObjects.Characters.PlayerClasses
{
    class Warrior : Player
    {
        private const string SpriteTexturePath = "player_sprite";
        private const string Type = "warrior";

        private const int textureWidth = 113;
        private const int textureHeight = 112;
        
        private const int DefaultHealthPoints = 1;
        private const int DefaultAttackPoints = 1;
        private const int DefaultDefensePoints = 1;
        private const int DefaultRange = 1;
        private const int default_stepSize = 2;

        public Warrior(Vector2 position)
            : base(
                  SpriteTexturePath,
                  Type,
                  position, 
                  DefaultHealthPoints, 
                  DefaultAttackPoints, 
                  DefaultDefensePoints, 
                  DefaultRange, 
                  default_stepSize, 
                  textureHeight, 
                  textureWidth)
        {
        }

        public override void Attack(KeyboardState state, IMap map)
        {
            if (state.IsKeyDown(Keys.Space))
            {
                this.IncrementX(1);
            }
        }

    }
}
