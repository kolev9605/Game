namespace LaharaGame.GameObjects.Characters.EnemyClasses
{
    using Microsoft.Xna.Framework;

    class Lizard : Enemy
    {
        private const string SpriteTexturePath = "monster-lizard";
        private const string Type = "lizard";

        private const int textureWidth = 80;
        private const int textureHeight = 56;

        private const int DefaultHealthPoints = 1;
        private const int DefaultAttackPoints = 1;
        private const int DefaultDefensePoints = 1;
        private const int DefaultRange = 1;
        private const int DefaultStepSize = 1;


        public Lizard(Vector2 position) 
            : base(
                  SpriteTexturePath, 
                  Type,
                  position,
                  DefaultHealthPoints,
                  DefaultAttackPoints,
                  DefaultDefensePoints,
                  DefaultRange,
                  DefaultStepSize,
                  textureHeight,
                  textureWidth)
        {
        }
    }
}
