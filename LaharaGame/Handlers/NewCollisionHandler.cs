using LaharaGame.Data;
using LaharaGame.GameObjects.Characters;
using LaharaGame.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaharaGame.Handlers
{
    public class NewCollisionHandler
    {
        private int windowHeight;
        private int windowWidth;

        public bool isCollision(Character character, IMap map, MonsterData monsters)
        {
            var screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            var screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            foreach (var tile in map.NewTiles.Where(t => !t.IsSteppable))
            {
                if (character.Bounds.Intersects(tile.Bounds))
                { 
                    return true;
                }
            }

            foreach (var monster in monsters.enemies)
            {
                if (character.Bounds.Intersects(monster.Bounds))
                {
                    return true;
                }
            }

            if (character.Position.X <= 0
                || character.Position.Y <= 0
                || character.Position.X + character.TextureWidth >= 800
                || character.Position.Y + character.TextureHeight >= 480)
            {
                return true;
            }

            return false;
        }
    }
}
