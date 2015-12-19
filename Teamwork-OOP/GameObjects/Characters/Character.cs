using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Teamwork_OOP.InputHandler;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.GameObjects.Characters
{
    public abstract class Character : GameObject, IAttack, IMovable, IAct
    {
        private readonly uint id;
        private Texture2D characterTexture;
        private Vector2 position;
        private int healthPoints;
        private int attackPoints;
        private int defencePoints;
        private int range;

        protected Character(
            string spriteTexturePath,
            string type,
            Vector2 position,
            int healthPoints,
            int attackPoints,
            int defencePoints,
            int range,
            int stepSize,
            int textureHeight,
            int textureWidth)
        {
            this.SpriteTexturePath = spriteTexturePath;
            this.Type = type;
            this.Position = position;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefencePoints = defencePoints;
            this.Range = range;
            this.StepSize = stepSize;
            this.TextureHeight = textureHeight;
            this.TextureWidth = textureWidth;


            this.FramesPerSecond = 5;
            this.IsMoving = false;
            this.Animations = new Dictionary<string, Rectangle[]>();

            PlayAnimation("idleDown");
        }

        //TODO: More validation
        public uint Id
        {
            get { return this.id; }
        }

        public string SpriteTexturePath { get; set; }

        public string Type { get; set; }

        public Texture2D CharacterTexture
        {
            get { return this.characterTexture; }
            set
            {
                if (value == null)
                {
                    throw new FileNotFoundException();
                }
                this.characterTexture = value;
            }
        }

        public int TextureWidth { get; set; }

        public int TextureHeight { get; set; }

        public Vector2 Position
        {
            get { return this.position; }
            private set { this.position = value; }
        }

        public int HealthPoints
        {
            get { return this.healthPoints; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.healthPoints = value;
            }
        }

        public int AttackPoints { get; set; }

        public int DefencePoints
        {
            get { return this.defencePoints; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.defencePoints = value;
            }
        }

        public int Range
        {
            get { return this.range; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.range = value;
            }
        }

        public int StepSize { get; set; }

        public bool IsMoving { get; set; }

        public bool IsAlive { get; set; }
        

        public Dictionary<string, Rectangle[]> Animations { get; set; }

        public int FramesPerSecond
        {
            set
            {
                this.TimeToUpdate = (1f / value);
            }
        }

        public int FrameIndex { get; set; }

        public double TimeElapsed { get; set; }

        public double TimeToUpdate { get; set; }

        public void LoadContent(ContentManager content)
        {
            this.CharacterTexture = content.Load<Texture2D>(this.SpriteTexturePath);
            //TODO fix this switch so the code is reusable
            switch (this.Type)
            {
                case "warrior":
                    this.AddAnimation(10, 113, 0, "runDown", 113, 112, new Vector2(0, 0));
                    this.AddAnimation(10, 113 * 2, 0, "runUp", 113, 112, new Vector2(0, 0));
                    this.AddAnimation(10, 113 * 3, 0, "runRight", 113, 112, new Vector2(0, 0));
                    this.AddAnimation(10, 113 * 5, 0, "runLeft", 113, 112, new Vector2(0, 0));
                    this.AddAnimation(3, 0, 0, "idleDown", 113, 112, new Vector2(0, 0));
                    this.AddAnimation(3, 0, 8, "idleUp", 113, 112, new Vector2(0, 0));
                    this.AddAnimation(3, 0, 12, "idleRight", 113, 112, new Vector2(0, 0));
                    this.AddAnimation(3, 113 * 2, 12, "idleLeft", 113, 112, new Vector2(0, 0));
                    break;
                //case "monster-lizard":
                //    AddAnimation(5, 56 * 1, 0, "runRight", 80, 56, new Vector2(0, 0));
                //    AddAnimation(5, 56 * 2, 0, "runLeft", 80, 56, new Vector2(0, 0));
                //    AddAnimation(5, 56 * 4, 0, "runDown", 80, 56, new Vector2(0, 0));
                //    AddAnimation(5, 56 * 6, 0, "runUp", 80, 56, new Vector2(0, 0));
                //    AddAnimation(5, 56 * 1, 0, "idleRight", 80, 56, new Vector2(0, 0));
                //    AddAnimation(5, 56 * 3, 0, "idleLeft", 80, 56, new Vector2(0, 0));
                //    AddAnimation(5, 56 * 5, 0, "idleDown", 80, 56, new Vector2(0, 0));
                //    AddAnimation(5, 56 * 7, 0, "idleUp", 80, 56, new Vector2(0, 0));
                //    break;
                case "shadow":
                    AddAnimation(3, 32 * 0, 3, "runRight", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 0, 9, "runLeft", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 0, 0, "runDown", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 0, 6, "runUp", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 0, 3, "idleRight", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 0, 9, "idleLeft", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 0, 0, "idleDown", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 0, 6, "idleUp", 32, 32, new Vector2(0, 0));
                    break;
                case "skeleton":
                    AddAnimation(3, 32 * 1, 3, "runRight", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 1, 9, "runLeft", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 1, 0, "runDown", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 1, 6, "runUp", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 1, 3, "idleRight", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 1, 9, "idleLeft", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 1, 0, "idleDown", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * 1, 6, "idleUp", 32, 32, new Vector2(0, 0));
                    break;
            }
        }

        public void AddAnimation(int frames, int y, int startFrame, string name, int width, int height, Vector2 offset)
        {
            Rectangle[] currAnimation = new Rectangle[frames];
            
            for (int i = 0; i < frames; i++)
            {
                currAnimation[i] = new Rectangle((i + startFrame) * width, y, width, height);
            }
            
            if (!this.Animations.ContainsKey(name))
            {
                this.Animations.Add(name, currAnimation);
            }
            else
            {
                //TODO VALIDATE WITH EXCEPTION
            }
        }

        public void PlayAnimation(string name)
        {
            if (this.CurrentAnimation != name)
            {
                this.CurrentAnimation = name;
                this.FrameIndex = 0;
            }
        }

        public string CurrentAnimation { get; set; }
        

        public abstract void Act(KeyboardState state, IMap map);

        public void Update(GameTime gameTime)
        {
            //calculating the time to update the animation
            this.TimeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            if (this.TimeElapsed > this.TimeToUpdate)
            {
                this.TimeElapsed -= this.TimeToUpdate;

                if (this.FrameIndex < this.Animations[this.CurrentAnimation].Length - 1)
                {
                    this.FrameIndex += 1;
                }
                else
                {
                    this.FrameIndex = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.characterTexture, this.Position, this.Animations[this.CurrentAnimation][this.FrameIndex], Color.White);
        }

        public abstract void Attack(KeyboardState state, IMap map);

        public abstract void Move(KeyboardState state, IMap map);

        //if you want to check for all edges of the texture when moving 
        //UNCOMMENT commented sections from left and right movement
        //REMOVE ctrl + f => shouldRemoveThis
        public void MoveRight(IMovable dude, IMap map)
        {
            if (!((int)this.Position.X + this.StepSize + this.TextureWidth >= map.Tiles.GetLength(1) * map.TileWidth))
            {
                int tempCol1 = (int)(this.Position.X + this.StepSize + this.TextureWidth) / map.TileWidth;

                //int tempRol1 = (int)(this.Position.Y) / Map.Map.TILE_DIMENTION;
                int tempRol2 = (int)(this.Position.Y + this.TextureHeight) / map.TileHeight;
                if (CollisionHandler.IsTileSteppable(tempRol2, tempCol1, map)/*&& CollisionHandler.IsTileSteppable(tempRol1, tempCol1,map)*/)
                    this.IncrementX(this.StepSize);
            }
        }
        public void MoveLeft(IMovable dude, IMap map)
        {
            if (!((int)this.Position.X - this.StepSize < 0))
            {
                int tempCol1 = (int)(this.Position.X - this.StepSize) / map.TileWidth;

                //int tempRol1 = (int)(this.Position.Y) / Map.Map.TILE_DIMENTION;
                int tempRol2 = (int)(this.Position.Y + this.TextureHeight) / map.TileHeight;
                if (CollisionHandler.IsTileSteppable(tempRol2, tempCol1, map)/*&& CollisionHandler.IsTileSteppable(tempRol1, tempCol1,map)*/ )
                    this.IncrementX(-this.StepSize);
            }
        }
        public void MoveUp(IMovable dude, IMap map)
        {
            if (!((int)this.Position.Y - this.StepSize < 0))
            {
                int tempCol1 = (int)this.Position.X / map.TileWidth;
                int tempCol2 = (int)(this.Position.X + this.TextureWidth) / map.TileWidth;

                int tempRol1 = (int)(this.Position.Y + this.TextureHeight - this.StepSize) / map.TileHeight;
                //^ shouldRemoveThis
                if (CollisionHandler.IsTileSteppable(tempRol1, tempCol1, map) && CollisionHandler.IsTileSteppable(tempRol1, tempCol2, map))
                    this.IncrementY(-this.StepSize);
            }
        }
        public void MoveDown(IMovable dude, IMap map)
        {
            if (!((int)this.Position.Y + this.StepSize + this.TextureHeight >= map.Tiles.GetLength(0) * map.TileHeight))
            {
                int tempCol1 = (int)this.Position.X / map.TileWidth;
                int tempCol2 = (int)(this.Position.X + this.TextureWidth) / map.TileWidth;

                int tempRol1 = (int)(this.Position.Y + this.StepSize + this.TextureHeight) / map.TileHeight;
                if (CollisionHandler.IsTileSteppable(tempRol1, tempCol1, map) && CollisionHandler.IsTileSteppable(tempRol1, tempCol2, map))
                    this.IncrementY(this.StepSize);
            }
        }

        public void IncrementX(int value)
        {
            this.position.X += value;
        }

        public void IncrementY(int value)
        {
            this.position.Y += value;
        }

        //TODO KPK FOR ALL CLASSES (CHECK DECLARATION ORDER, SHOULD BE =>
        //constants
        //fields
        //constructors
        //properties
        //methods
        //TODO order for all of the above =>
        //public / protected / internal / private /
    }
}
