using LaharaGame.GameObjects.Characters;
using LaharaGame.Interfaces;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LaharaGame.Data
{
    public class MonsterDataDict
    {
        public Dictionary<Vector2, Character> enemies = new Dictionary<Vector2, Character>();

        public void AddEnemy(Character enemy)
        {
            this.enemies.Add(enemy.Position, enemy);
        }
    }
}