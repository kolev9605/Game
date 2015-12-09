
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Teamwork_OOP.GameObjects.Map.Tiles;

namespace Teamwork_OOP.GameObjects.Map
{
    public class Map
    {
        //TODO Should have a GFX handler that has every key value pair for: string => texture 
        public List<Tile> Tiles { get; set; }

        public Map()
        {
            this.Tiles = new List<Tile>();
        }
        

        

        public void Initialize()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    this.Tiles.Add(new Tile("grass_tile", new Vector2(i*50, k*50)));
                }
            }
        }
        
         
    }
}