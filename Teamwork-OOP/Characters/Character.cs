using Microsoft.Xna.Framework;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.Characters
{
    public abstract class Character : GameObject, IKillable, IAttack
    {
        private readonly uint id; //unique id for every character type 
        private int healthPoints; //starting health points
        private int attackPoints;  //starting attack points
        private int defensePoints; //the amount of damage reduction on every attack
        private Vector2 currentPosition; // position on the matrix (x,y)
        private bool isAlive;
        private uint range;
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

        public Vector2 CurrentPosition
        {
            get { return currentPosition; }
            set { currentPosition = value; }
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
