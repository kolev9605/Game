namespace LaharaGame.GameObjects.Characters
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using InputHandler;
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Handlers;
    using Data;
    using Enums;

    public abstract class Character : GameObject, IAttack, IMovable, IAct
    {
        private NewCollisionHandler collisionHandler;

        private readonly uint id;
        private Texture2D characterTexture;
        private Texture2D healthBarRTexture;
        private Texture2D healthBarGTexture;
        private Vector2 position;
        private int healthPoints;
        private int attackPoints;
        private int defencePoints;
        private int range;
        private int initialHealthPoints;
        private AttackState attackState;

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
            int textureWidth,
            AttackState attackState = AttackState.notactivated)
        {
            this.SpriteTexturePath = spriteTexturePath;
            this.Type = type;
            this.Position = position;
            this.HealthPoints = healthPoints;
            this.initialHealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefencePoints = defencePoints;
            this.Range = range;
            this.StepSize = stepSize;
            this.TextureHeight = textureHeight;
            this.TextureWidth = textureWidth;
            this.Bounds = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.TextureWidth, this.TextureHeight);
            this.collisionHandler = new NewCollisionHandler();
            this.AttackState = attackState;


            this.FramesPerSecond = 5;
            this.IsMoving = false;
            this.Animations = new Dictionary<string, Rectangle[]>();

            PlayAnimation("idleDown");
        }

        public uint Id
        {
            get { return this.id; }
        }

        public Rectangle HealthBar { get; set; }

        public Rectangle Bounds;

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

        public Texture2D HealthBarRTexture
        {
            get { return this.healthBarRTexture; }
            set
            {
                if (value == null)
                {
                    throw new FileNotFoundException();
                }
                this.healthBarRTexture = value;
            }
        }

        public Texture2D HealthBarGTexture
        {
            get { return this.healthBarGTexture; }
            set
            {
                if (value == null)
                {
                    throw new FileNotFoundException();
                }
                this.healthBarGTexture = value;
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
                this.healthPoints = value;
            }
        }

        public int InitialHealthPoints
        {
            get
            {
                return this.initialHealthPoints;
            }
            set
            {
                this.initialHealthPoints = value;
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

        public AttackState AttackState
        {
            get
            {
                return this.attackState;
            }
            set
            {
                this.attackState = value;
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
            this.HealthBarGTexture = content.Load<Texture2D>("HealthBarG");
            this.HealthBarRTexture = content.Load<Texture2D>("HealthBarR");
            //TODO fix this switch so the code is reusable
            switch (this.SpriteTexturePath)
            {
                case "player_sprite_V3":
                    this.AddAnimation(10, this.TextureWidth, 0, "runDown", this.TextureWidth, this.TextureHeight, new Vector2(0, 0));
                    this.AddAnimation(10, this.TextureWidth * 2, 0, "runUp", this.TextureWidth, this.TextureHeight, new Vector2(0, 0));
                    this.AddAnimation(10, this.TextureWidth * 3, 0, "runRight", this.TextureWidth, this.TextureHeight, new Vector2(0, 0));
                    this.AddAnimation(10, this.TextureWidth * 5, 0, "runLeft", this.TextureWidth, this.TextureHeight, new Vector2(0, 0));
                    this.AddAnimation(3, 0, 0, "idleDown", this.TextureWidth, this.TextureHeight, new Vector2(0, 0));
                    this.AddAnimation(3, 0, 8, "idleUp", this.TextureWidth, this.TextureHeight, new Vector2(0, 0));
                    this.AddAnimation(3, 0, 12, "idleRight", this.TextureWidth, this.TextureHeight, new Vector2(0, 0));
                    this.AddAnimation(3, this.TextureWidth * 2, 12, "idleLeft", this.TextureWidth, this.TextureHeight, new Vector2(0, 0));
                    break;
                case "monsters":
                    int monsterFlag = GetMonsterFlag();
                    AddAnimation(3, 32 * monsterFlag, 3, "runRight", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * monsterFlag, 9, "runLeft", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * monsterFlag, 0, "runDown", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * monsterFlag, 6, "runUp", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * monsterFlag, 3, "idleRight", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * monsterFlag, 9, "idleLeft", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * monsterFlag, 0, "idleDown", 32, 32, new Vector2(0, 0));
                    AddAnimation(3, 32 * monsterFlag, 6, "idleUp", 32, 32, new Vector2(0, 0));
                    break;
            }
        }

        private int GetMonsterFlag()
        {
            int monsterModifier = 0;

            switch (this.Type)
            {
                case "shadow": return monsterModifier = 0;
                case "skeleton": return monsterModifier = 1;
                case "goblin": return monsterModifier = 2;
                case "gargoyle": return monsterModifier = 3;
                case "genie": return monsterModifier = 4;
                case "sorceress": return monsterModifier = 5;
                case "death": return monsterModifier = 6;
                case "sorceror": return monsterModifier = 7;
                default: break;
            }

            return monsterModifier;
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


        public abstract void Act(KeyboardState state, IMap map, List<Character> characters);

        public void Update(GameTime gameTime)
        {
            //calculating the time to update the animation
            if (healthPoints > 0)
            {
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (healthPoints > 0)
            {
                float greenBarWidth = ((float)this.HealthPoints / this.initialHealthPoints) * this.TextureWidth;

                spriteBatch.Draw(this.characterTexture, this.Position, this.Animations[this.CurrentAnimation][this.FrameIndex], Color.White);
                Rectangle HealthBarR = new Rectangle((int)this.Position.X, (int)this.Position.Y-9, this.TextureWidth, 3);
                Rectangle HealthBarG = new Rectangle((int)this.Position.X, (int)this.Position.Y-9, (int)greenBarWidth, 3);
                spriteBatch.Draw(HealthBarRTexture, HealthBarR, Color.White);
                spriteBatch.Draw(HealthBarGTexture, HealthBarG, Color.White);
            }
        }

        public abstract void Attack(KeyboardState state, IMap map, List<Character> characters);

        public abstract void Move(KeyboardState state, IMap map, List<Character> characters);

        public void MoveRight(IMovable dude, IMap map, List<Character> characters)
        {
            if (!this.collisionHandler.isCollision(this, map, characters))
            {
                this.IncrementX(this.StepSize);
            }
            else
            {
                this.IncrementX(-this.StepSize * 3);
            }
        }

        public void MoveLeft(IMovable dude, IMap map, List<Character> characters)
        {
            if (!this.collisionHandler.isCollision(this, map, characters))
            {
                this.IncrementX(-this.StepSize);
            }
            else
            {
                this.IncrementX(this.StepSize * 3);
            }
        }

        public void MoveUp(IMovable dude, IMap map, List<Character> characters)
        {
            if (!this.collisionHandler.isCollision(this, map, characters))
            {
                this.IncrementY(-this.StepSize);
            }
            else
            {
                this.IncrementY(this.StepSize * 3);
            }
        }

        public void MoveDown(IMovable dude, IMap map, List<Character> characters)
        {
            if (!this.collisionHandler.isCollision(this, map, characters))
            {
                this.IncrementY(this.StepSize);
            }
            else
            {
                this.IncrementY(-this.StepSize * 3);
            }
        }

        public void IncrementX(int value)
        {
            this.position.X += value;
            this.Bounds.X += value;
        }

        public void IncrementY(int value)
        {
            this.position.Y += value;
            this.Bounds.Y += value;
        }
    }
}
