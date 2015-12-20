using LaharaGame.GameObjects.Characters;
using LaharaGame.Interfaces;
using System.Collections.Generic;

namespace LaharaGame.Data
{
    public class MonsterData
    {
        public List<Character> enemies = new List<Character>();

        public void AddEnemy(Character enemy)
        {
            this.enemies.Add(enemy);
        }
    }
}
