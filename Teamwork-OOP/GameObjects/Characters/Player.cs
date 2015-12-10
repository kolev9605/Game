using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Teamwork_OOP.GameObjects.Characters
{
    class Player : Character
    {
        private int frameIndex;
        private Texture2D playerSprite;
        private Dictionary<string, Rectangle[]> animations; // dictionary for storing all animations
        private double timeElapsed;
        private double timeToUpdate;
        private string currentAnimation;
        private bool isMoving;
        private int stepSize;

        public int FramesPerSecond
        {
            set
            {
                //calculating the time for updating ..
                this.timeToUpdate = (1f / value);
            }
        }

        public Texture2D PlayerSprite
        {
            get { return this.playerSprite; }
            set { this.playerSprite = value; }
        }

        public Player(Vector2 possition)
            : base(possition)
        {
            //setting the animation FPS to 12
            this.FramesPerSecond = 12;
            //setting the player moving speed 
            this.StepSize = 5; 
            this.isMoving = false;
            //initialize the animations dictionary
            this.animations = new Dictionary<string, Rectangle[]>();

            //playing initial animation
            PlayAnimation("idleDown"); 
        }

        public void LoadContent(ContentManager content)
        {
            //loading the sprite sheet
            this.playerSprite = content.Load<Texture2D>("player_sprite_V2");

            //adding all animation to the dictionary
            AddAnimation(10, 113, 0, "runDown", 113, 112, new Vector2(0, 0));
            AddAnimation(10, 113 * 2, 0, "runUp", 113, 112, new Vector2(0, 0));
            AddAnimation(10, 113 * 3, 0, "runRight", 113, 112, new Vector2(0, 0));
            AddAnimation(10, 113 * 5, 0, "runLeft", 113, 112, new Vector2(0, 0));
            AddAnimation(3, 0, 0, "idleDown", 113, 112, new Vector2(0, 0));
            //AddAnimation(3, 0, 4, "idleDownv2", 113, 112, new Vector2(0, 0));
            AddAnimation(3, 0, 8, "idleUp", 113, 112, new Vector2(0, 0));
            AddAnimation(3, 0, 12, "idleRight", 113, 112, new Vector2(0, 0));
            AddAnimation(3, 113 * 2, 12, "idleLeft", 113, 112, new Vector2(0, 0));
        }

        protected Player(
            Texture2D texture,
            Vector2 possition,
            int healthPoints,
            int attackPoints,
            int defencePoints,
            int range)
            : base (texture, possition, healthPoints, attackPoints, defencePoints, range)
        {
        }

        public int StepSize
        {
            get { return this.stepSize; }
            private set { this.stepSize = value; }
        }  

        public void Move(KeyboardState state, Map.Map map)
        {
            //TODO FIX MOVEMENT ( NEED MORE KPK)
            //TODO Character should implement Imovable (all imovables have vector2 position and method Move())


            if (state.IsKeyDown(Keys.Right))
            {
                //playing the runRight animation
                PlayAnimation("runRight");
                this.isMoving = true;
                if (!((int)this.Position.X + this.StepSize >= map.Tiles.GetLength(1) * 50))
                {
                    int tempCol = (int)(this.Position.X + this.StepSize) / 50;
                    int tempRol = (int)(this.Position.Y) / 50;
                    if (map.CanStepOn(tempRol, tempCol))
                        this.IncrementX(this.StepSize);
                }
            }

            if (state.IsKeyDown(Keys.Down))
            {
                //playing the runDown animation
                PlayAnimation("runDown");
                this.isMoving = true;
                if (!((int)this.Position.Y + this.StepSize >= map.Tiles.GetLength(0) * 50))
                {
                    int tempCol = (int)this.Position.X / 50;
                    int tempRol = (int)(this.Position.Y + this.StepSize) / 50;
                    if (map.CanStepOn(tempRol, tempCol))
                        this.IncrementY(this.StepSize);
                }
            }

            if (state.IsKeyDown(Keys.Left))
            {
                //playing the runLeft animation
                PlayAnimation("runLeft");
                this.isMoving = true;
                if (!((int)this.Position.X - this.StepSize < 0))
                {
                    int tempCol = (int)(this.Position.X - this.StepSize) / 50;
                    int tempRol = (int)(this.Position.Y) / 50;
                    if (map.CanStepOn(tempRol, tempCol))
                        this.IncrementX(-this.StepSize);
                }
            }

            if (state.IsKeyDown(Keys.Up))
            {
                //playing the runUp animation
                PlayAnimation("runUp");
                this.isMoving = true;
                if (!((int)this.Position.Y - this.StepSize < 0))
                {
                    int tempCol = (int)this.Position.X / 50;
                    int tempRol = (int)(this.Position.Y - this.StepSize) / 50;
                    if (map.CanStepOn(tempRol, tempCol))
                        this.IncrementY(-this.StepSize);
                }
            }

            //setting the state to idle if the player is not moving
            if (!this.isMoving)
            {
                if (this.currentAnimation.Contains("Down"))
                {
                    PlayAnimation("idleDown");
                }
                if (this.currentAnimation.Contains("Up"))
                {
                    PlayAnimation("idleUp");
                }
                if (this.currentAnimation.Contains("Left"))
                {
                    PlayAnimation("idleLeft");
                }
                if (this.currentAnimation.Contains("Right"))
                {
                    PlayAnimation("idleRight");
                }
            }

            //at the end of every update setting isMoving to false
            this.isMoving = false;
        }

        //methond for adding animation to our dictionary
        public void AddAnimation(int frames, int y, int startFrame, string name, int width, int height, Vector2 offset)
        {
            //int width = 113;
            //int height = 112;

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
            spriteBatch.Draw(this.playerSprite, this.Position, this.animations[this.currentAnimation][this.frameIndex], Color.White);
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