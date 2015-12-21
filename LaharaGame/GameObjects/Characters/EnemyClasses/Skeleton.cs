namespace LaharaGame.GameObjects.Characters.EnemyClasses
{
    using Microsoft.Xna.Framework;

    class Skeleton : Enemy
    {
        private const string SpriteTexturePath = "monsters";
        private const string Type = "skeleton";

        private const int textureWidth = 32;
        private const int textureHeight = 32;

        private const int DefaultHealthPoints = 1000;
        private const int DefaultAttackPoints = 3;
        private const int DefaultDefensePoints = 1;
        private const int DefaultRange = 1;
        private const int DefaultStepSize = 1;


        public Skeleton(Vector2 position)
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
