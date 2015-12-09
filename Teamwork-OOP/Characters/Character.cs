using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.Characters
{
    public abstract class Character : GameObject, IKillable, IAttack
    {
        private readonly uint id; //unique id for every character type 
        private int healthPoints; //starting health points
        private int attackPoints;  //starting attack points
        private int defensePoints; //the amount of damage reduction on every attack
        private uint range;
        private Vector2 position; // position on the matrix (x,y)
        private Texture2D texture; 
        private bool isAlive;
        private bool isRanged;

        public uint Id
        {
            get { return this.id; }
        }

        public int HealthPoints
        {
            get { return healthPoints; }
            set { healthPoints = value; }
        }

        public int AttackPoints
        {
            get { return attackPoints; }
            set { attackPoints = value; }
        }

        public void Attack(IAttackable target)
        {
            throw new System.NotImplementedException();
        }

        public int DefensePoints
        {
            get { return defensePoints; }
            set { defensePoints = value; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Texture2D Texture
        {
            get { return this.texture; }
            set { this.texture = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public uint Range
        {
            get { return range; }
            set { range = value; }
        }

        public bool IsRanged
        {
            get { return isRanged; }
            set { isRanged = value; }
        }
        
    }
}
