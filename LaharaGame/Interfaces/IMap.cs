using System.Collections.Generic;

namespace LaharaGame.Interfaces
{
    public interface IMap
    {
        string Src { get; set; }

        ITile[,] Tiles { get; set; }
        
        int TileWidth { get; }

        int TileHeight { get; }

        void Initialize(IMapFactory mapFactory, ITileFactory tileFactory);

        void AddTile(ITile tile);

        List<ITile> NewTiles { get;}
    }
}