namespace LaharaGame.GameObjects.Characters.EnemyClasses
{
    using Microsoft.Xna.Framework;

    class Death : Enemy
    {
        private const string SpriteTexturePath = "monsters";
        private const string Type = "death";

        private const int textureWidth = 32;
        private const int textureHeight = 32;

        private const int DefaultHealthPoints = 600;
        private const int DefaultAttackPoints = 3;
        private const int DefaultDefensePoints = 1;
        private const int DefaultRange = 1;
        private const int DefaultStepSize = 1;


        public Death(Vector2 position)
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
