namespace LaharaGame.GameObjects.Characters.PlayerClasses
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    class Warrior : Player
    {
        private const string SpriteTexturePath = "player_sprite_V3";
        private const string Type = "warrior";

        private const int textureWidth = 45;
        private const int textureHeight = 45;
        
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
