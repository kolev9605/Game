namespace LaharaGame.Factories
{
    using System.IO;
    using Interfaces;
    using Microsoft.Xna.Framework;

    public class MapFactory : IMapFactory
    {
        public void Initialize(IMap map,string source, ITileFactory tileFactory)
        {
            StreamReader reader = new StreamReader(source);
            using (reader)
            {
                string[] line = reader.ReadLine().Split();
                int rows = int.Parse(line[0]);
                int cols = int.Parse(line[1]);

                map.Tiles = new ITile[rows, cols];


                string getLine = reader.ReadLine();
                int currentLine = 0;
                while (getLine != null)
                {
                    for (int i = 0; i < getLine.Length; i++)
                    {
                        switch (getLine[i])
                        {
                            case 'G':
                                var newTile = tileFactory.Make("grass_tile", true, new Vector2(i * map.TileWidth, currentLine * map.TileHeight));
                                map.Tiles[currentLine, i] = newTile;
                                map.AddTile(newTile);
                                continue;
                            case 'R':
                                var newTile2 = tileFactory.Make("rock_tile", false, new Vector2(i * map.TileWidth, currentLine * map.TileHeight));
                                map.Tiles[currentLine, i] = newTile2;
                                map.AddTile(newTile2);
                                continue;
                        }
                    }

                    getLine = reader.ReadLine();
                    currentLine++;
                }
            }
        }
    }
}