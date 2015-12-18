using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Teamwork_OOP.InputHandler;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.GameObjects.Characters
{
    public abstract class Character : GameObject, IAttack, IMovable
    {
        private readonly uint id;
        private Texture2D characterTexture;
        private Vector2 position;
        private int healthPoints;
        private int attackPoints;
        private int defencePoints;
        private int range;
        private bool isAlive;

        protected Character(
            Vector2 possition,
            int healthPoints,
            int attackPoints,
            int defencePoints,
            int range,
            int stepSize,
            int textureHeight,
            int textureWidth)
        {
            this.Position = possition;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefencePoints = defencePoints;
            this.Range = range;
            this.StepSize = stepSize;
            this.TextureHeight = textureHeight;
            this.TextureWidth = textureWidth;
        }

        //TODO: More validation
        public uint Id
        {
            get { return this.id; }
        }

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

        public void IncrementX(int value)
        {
            this.position.X += value;
        }

        public void IncrementY(int value)
        {
            this.position.Y += value;
        }

        public int TextureWidth { get; set; }

        public int TextureHeight { get; set; }

        public bool IsAlive
        {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }

        public void Attack(IAttackable target)
        {
            throw new System.NotImplementedException();
        }

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
