using LaharaGame.GameObjects.Characters;
using LaharaGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaharaGame.Handlers
{
    public class NewCollisionHandler
    {
        public bool isCollision(Character character, IMap map)
        {
            foreach (var tile in map.NewTiles.Where(t => !t.IsSteppable))
            {
                if (character.Bounds.Intersects(tile.Bounds))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
