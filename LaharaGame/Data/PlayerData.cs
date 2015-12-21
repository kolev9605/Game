using LaharaGame.GameObjects.Characters;
using LaharaGame.Interfaces;
using System.Collections.Generic;

namespace LaharaGame.Data
{
    public class PlayerData
    {
        public List<Character> players = new List<Character>();

        public void AddEnemy(Character player)
        {
            this.players.Add(player);
        }
    }
}
