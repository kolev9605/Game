using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Teamwork_OOP.GameObjects.Characters.PlayerClasses
{
    class Warrior : Player
    {
        private const int textureWidth = 113;
        private const int textureHeight = 112;
        //TODO THESE -------^ SHOULD BE TAKEN AUTOMATICALLY FROM TEXTURE OR WHATEVER
        private const int DefaultHealthPoints = 1;
        private const int DefaultAttackPoints = 1;
        private const int DefaultDefensePoints = 1;
        private const int DefaultRange = 1;
        private const int default_stepSize = 2;
        //TODO CHANGE THOSE^ ACCORDINGLY

        public Warrior(Vector2 possition)
            : base(possition, DefaultHealthPoints, DefaultAttackPoints, DefaultDefensePoints, DefaultRange, default_stepSize, textureHeight, textureWidth)
        {
        }

        public override void LoadContent(ContentManager content)
        {
            //loading the sprite sheet
            this.PlayerSprite = content.Load<Texture2D>("player_sprite_V2");
            //adding all animation to the dictionary


            this.AddAnimation(10, 113, 0, "runDown", 113, 112, new Vector2(0, 0));
            this.AddAnimation(10, 113 * 2, 0, "runUp", 113, 112, new Vector2(0, 0));
            this.AddAnimation(10, 113 * 3, 0, "runRight", 113, 112, new Vector2(0, 0));
            this.AddAnimation(10, 113 * 5, 0, "runLeft", 113, 112, new Vector2(0, 0));
            this.AddAnimation(3, 0, 0, "idleDown", 113, 112, new Vector2(0, 0));
            //AddAnimation(3, 0, 4, "idleDownv2", 113, 112, new Vector2(0, 0));
            this.AddAnimation(3, 0, 8, "idleUp", 113, 112, new Vector2(0, 0));
            this.AddAnimation(3, 0, 12, "idleRight", 113, 112, new Vector2(0, 0));
            this.AddAnimation(3, 113 * 2, 12, "idleLeft", 113, 112, new Vector2(0, 0));
            //TODO CHANGE THESE ---------------------^ values to this.textureWidth and this.textureHeight;
        }
    }
}
