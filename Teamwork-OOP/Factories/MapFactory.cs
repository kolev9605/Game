using System.IO;
using Microsoft.Xna.Framework;
using Teamwork_OOP.GameObjects.Map.Tiles;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP.Factories
{
    public class MapFactory : IMapFactory
    {
        public void Initialize(IMap map,string src, ITileFactory tileFactory)
        {
            StreamReader reader = new StreamReader(src);
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
                                map.Tiles[currentLine, i] = tileFactory.Make("grass_tile", true, new Vector2(i * map.TileWidth, currentLine * map.TileHeight));
                                continue;
                            case 'R':
                                map.Tiles[currentLine, i] = tileFactory.Make("rock_tile", false, new Vector2(i * map.TileWidth, currentLine * map.TileHeight));
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