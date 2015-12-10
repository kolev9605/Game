using System.IO;
using Microsoft.Xna.Framework;
using Teamwork_OOP.GameObjects.Map.Tiles;

namespace Teamwork_OOP.GameObjects.Map
{
    public class Map
    {
        private Tile[,] tiles;
        public Tile[,] Tiles { get; set; }

        public Map()
        {
        }
        
        //TODO become ReadLevel which initializes level from file
        public void Initialize()
        {
            
            //StreamReader reader = new StreamReader(string.Format("../../using/Level{0}.txt", currentLevel));
            //TODO THIS ^
            StreamReader reader = new StreamReader("../../../Content/Levels/Level1.txt");
            using (reader)
            {
                string[] line = reader.ReadLine().Split();
                int rows = int.Parse(line[0]);
                int cols = int.Parse(line[1]);

                this.Tiles = new Tile[rows,cols];

                string getLine = reader.ReadLine();
                int currentLine = 0;
                while (getLine != null)
                {
                    for (int i = 0; i < getLine.Length; i++)  
                    {
                        //TODO add cases to this switch for new tiles
                        switch (getLine[i])
                        {
                            case 'G':
                                this.Tiles[currentLine, i] = new Tile("grass_tile", true, new Vector2(i * 50, currentLine * 50));
                                continue;
                            case 'R':
                                this.Tiles[currentLine, i] = new Tile("rock_tile", false , new Vector2(i * 50, currentLine * 50));
                                continue;
                        }
                        //TODO true and false in TILE constructor should be gone => tile should set those based on type

                    }

                    getLine = reader.ReadLine();
                    currentLine++;
                }
            }
        }


        public bool CanStepOn(int TileRow, int TileCol)
        {
            return this.Tiles[TileRow, TileCol].IsSteppable;
        }
    }
}