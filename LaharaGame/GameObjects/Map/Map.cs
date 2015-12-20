namespace LaharaGame.GameObjects.Map
{
    using Interfaces;
    using System.Collections.Generic;

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

        private List<ITile> newTiles = new List<ITile>();

        public List<ITile> NewTiles { get { return this.newTiles; } }

        public void AddTile(ITile tile)
        {
            newTiles.Add(tile);
        }

        public int TileWidth { get; private set; }

        public int TileHeight { get; private set; }
        
        public void Initialize(IMapFactory mapFactory, ITileFactory tileFactory)
        {
            mapFactory.Initialize(this, this.Src, tileFactory);
        }

    }
}