﻿namespace Teamwork_OOP.GameObjects.Map
{
    using Teamwork_OOP.Interfaces;

    public class Map : IMap
    {
        public Map(string mapSRC, int tileWidth, int tileHeight)
        {
            this.Src = mapSRC;
            this.TileWidth = tileWidth;
            this.TileHeight = tileHeight;
        }

        public string Src { get; set; }

        public ITile[,] Tiles { get; set; }

        public int TileWidth { get; private set; }

        public int TileHeight { get; private set; }
        
        public void Initialize(IMapFactory mapFactory, ITileFactory tileFactory)
        {
            mapFactory.Initialize(this, this.Src, tileFactory);
        }

    }
}