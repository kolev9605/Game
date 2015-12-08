using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using IDrawable = Teamwork_OOP.Interfaces.IDrawable;

namespace Teamwork_OOP.Maps
{
    public class Map : IDrawable
    {
        private Tile[,] playingField = new Tile[10,10];

        public Map(Tile playingFieldTile)
        {
            this.PlayingFieldTile = playingFieldTile;
        }

        public Tile PlayingFieldTile { get; set; }


        public void LoadContent()
        {
            throw new NotImplementedException();
        }

        public void UnloadContent()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}