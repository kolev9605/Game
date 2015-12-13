using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Teamwork_OOP.GameObjects.Characters
{
    class Enemy : Character
    {
        private const int textureWidth = 80;
        private const int textureHeight = 56;
        //TODO THESE -------^ SHOULD BE TAKEN AUTOMATICALLY FROM TEXTURE OR WHATEVER
        private const int Default_stepSize = 4;
        private int frameIndex;
        private Texture2D enemySprite;
        private Dictionary<string, Rectangle[]> animations; // dictionary for storing all animations
        private double timeElapsed;
        private double timeToUpdate;
        private string currentAnimation;
        private bool isMoving;

        public Enemy(Vector2 position)
            : base(position, Default_stepSize,textureHeight,textureWidth)
        {
            //setting the animation FPS to 12
            this.FramesPerSecond = 12;
            //setting the player moving speed 
            this.isMoving = false;
            //initialize the animations dictionary
            this.animations = new Dictionary<string, Rectangle[]>();

            //playing initial animation
            PlayAnimation("idleDown");
        }

        protected Enemy(
            Texture2D texture,
            Vector2 possition,
            int healthPoints,
            int attackPoints,
            int defencePoints,
            int range)
            : base(texture, possition, healthPoints, attackPoints, defencePoints, range)
        {

        }

        public int FramesPerSecond
        {
            set
            {
                //calculating the time for updating ..
                this.timeToUpdate = (1f / value);
            }
        }

        public Texture2D EnemySprite
        {
            get { return this.enemySprite; }
            set { this.enemySprite = value; }
        }

        public void LoadContent(ContentManager content)
        {
            //loading the sprite sheet
            this.enemySprite = content.Load<Texture2D>("monster-lizard");

            //adding all animation to the dictionary


            AddAnimation(5, 56 * 0, 0, "runRight", 80, 56, new Vector2(0, 0));
            AddAnimation(5, 56 * 2, 0, "runLeft", 80, 56, new Vector2(0, 0));
            AddAnimation(5, 56 * 4, 0, "runDown", 80, 56, new Vector2(0, 0));
            AddAnimation(5, 56 * 6, 0, "runUp", 80, 56, new Vector2(0, 0));
            AddAnimation(5, 56 * 1, 0, "idleRight", 80, 56, new Vector2(0, 0));
            AddAnimation(5, 56 * 3, 0, "idleLeft", 80, 56, new Vector2(0, 0));
            AddAnimation(5, 56 * 5, 0, "idleDown", 80, 56, new Vector2(0, 0));
            AddAnimation(5, 56 * 7, 0, "idleUp", 80, 56, new Vector2(0, 0));
            //TODO CHANGE THESE ---------------------^ values to this.textureWidth and this.textureHeight;
        }

        public void Move()
        {
            //TODO add custom random moving of mosters
        }

        //methond for adding animation to our dictionary
        public void AddAnimation(int frames, int y, int startFrame, string name, int width, int height, Vector2 offset)
        {
            //creating the curretnt animation array
            Rectangle[] currAnimation = new Rectangle[frames];

            //filling the array with the current animation parts of the spritesheet
            for (int i = 0; i < frames; i++)
            {
                currAnimation[i] = new Rectangle((i + startFrame) * width, y, width, height);
            }

            //adding the current animation to the dictionary
            if (!this.animations.ContainsKey(name))
            {
                this.animations.Add(name, currAnimation);
            }
            else
            {
                //TODO VALIDATE WITH EXCEPTION
            }

        }

        public void Update(GameTime gameTime)
        {
            //calculating the time to update the animation
            this.timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timeElapsed > this.timeToUpdate)
            {
                this.timeElapsed -= this.timeToUpdate;

                if (this.frameIndex < this.animations[this.currentAnimation].Length - 1)
                {
                    this.frameIndex++;
                }
                else
                {
                    this.frameIndex = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.enemySprite, this.Position, this.animations[this.currentAnimation][this.frameIndex], Color.White);
        }

        public void PlayAnimation(string name)
        {
            if (this.currentAnimation != name)
            {
                this.currentAnimation = name;
                this.frameIndex = 0;
            }
        }
    }
}
