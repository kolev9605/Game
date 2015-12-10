using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.GameObjects.Characters
{
    public abstract class Character : GameObject, IAttack, IMovable
    {
        private readonly uint id;

        // Stats
        private int healthPoints;
        private int attackPoints; 
        private int defencePoints;
        private int range;

        private bool isAlive;

        private Vector2 position;
        //TODO: Figure a way to remove this field and have the .x and .y setters work ( see increment method)

        private Texture2D characterTexture;
        //TODO: Add character StepSize ( how many pixels this travels on each step )

        // Constructor to set the initial possition and texture
        protected Character(Texture2D texture, Vector2 possition)
        {
            this.CharacterTexture = texture;
            this.Position = possition;
        }

        protected Character(
            Texture2D texture, 
            Vector2 possition, 
            int healthPoints, 
            int attackPoints, 
            int defencePoints,
            int range)
        {
            this.CharacterTexture = texture;
            this.Position = possition;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefencePoints = defencePoints;
            this.Range = range;
        }

        //TODO: More validation
        public uint Id
        {
            get { return this.id; }
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

        public int AttackPoints
        {
            get { return this.attackPoints; }
            set
            {
                if (value > 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.attackPoints = value;
            }
        }

        public void Attack(IAttackable target)
        {
            throw new System.NotImplementedException();
        }

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

        public bool IsAlive
        {
            get { return this.isAlive; }
            set { this.isAlive = value; }
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
            set
            {
                if (value.X < 0 || value.Y < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Coordinates cannot be negative.");
                }
                this.position = value;
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
