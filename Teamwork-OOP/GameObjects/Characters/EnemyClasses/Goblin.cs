namespace Teamwork_OOP.GameObjects.Characters.EnemyClasses
{
    using Microsoft.Xna.Framework;

    class Goblin : Enemy
    {
        private const string SpriteTexturePath = "monsters";
        private const string Type = "goblin";

        private const int textureWidth = 32;
        private const int textureHeight = 32;

        private const int DefaultHealthPoints = 1;
        private const int DefaultAttackPoints = 1;
        private const int DefaultDefensePoints = 1;
        private const int DefaultRange = 1;
        private const int DefaultStepSize = 1;


        public Goblin(Vector2 position)
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
