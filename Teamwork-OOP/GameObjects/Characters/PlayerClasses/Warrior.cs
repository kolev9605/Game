using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Teamwork_OOP.GameObjects.Characters.PlayerClasses
{
    class Warrior : Player
    {
        private const int DefaultHealthPoints = 1;
        private const int DefaultAttackPoints = 1;
        private const int DefaultDefensePoints = 1;
        private const int DefaultRange = 1;

        public Warrior(Texture2D texture, Vector2 possition) 
            : base(texture, possition, DefaultHealthPoints, DefaultAttackPoints, DefaultDefensePoints, DefaultRange)
        {
        }
    }
}
