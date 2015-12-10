using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.GameObjects.Characters
{
    public abstract class Character : GameObject, IAttack, IMovable
    {
        private readonly uint id; //unique id for every character type 
        private int healthPoints; //starting health points
        private int attackPoints;  //starting attack points
        private int defensePoints; //the amount of damage reduction on every attack
        private bool isAlive;
        private uint range;
        private bool isRanged;
        private Vector2 position; // position on the matrix (x,y)
        //TODO Figure a way to remove this field and have the .x and .y setters work ( see increment method)
        private Texture2D characterTexture;
        //TODO add character StepSize ( how many pixels this travels on each step )

        //constructor to set the initial possition and texture
        protected Character(Texture2D texture, Vector2 possition)
        {
            this.CharacterTexture = texture;
            this.Position = possition;
        }
        
        //TODO: VALIDATION
        public uint Id
        {
            get { return this.id; }
        }
        public int HealthPoints
        {
            get { return this.healthPoints; }
            set { this.healthPoints = value; }
        }
        public int AttackPoints
        {
            get { return this.attackPoints; }
            set { this.attackPoints = value; }
        }
        public void Attack(IAttackable target)
        {
            throw new System.NotImplementedException();
        }
        public int DefensePoints
        {
            get { return this.defensePoints; }
            set { this.defensePoints = value; }
        }
        public bool IsAlive
        {
            get { return this.isAlive; }
            set { this.isAlive = value; }
        }
        public uint Range
        {
            get { return this.range; }
            set { this.range = value; }
        }
        public bool IsRanged
        {
            get { return this.isRanged; }
            set { this.isRanged = value; }
        }

        //extracted character possition property
        
        //extracted character texture property
        public Texture2D CharacterTexture
        {
            get { return this.characterTexture; }
            set { this.characterTexture = value; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
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
