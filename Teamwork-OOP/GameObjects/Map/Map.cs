
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
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
                        switch (getLine[i])
                        {
                            case 'G':
                                this.Tiles[currentLine, i] = new Tile("grass_tile", new Vector2(currentLine * 50, i * 50));
                                continue;
                            case 'R':
                                this.Tiles[currentLine, i] = new Tile("rock_tile", new Vector2(currentLine * 50, i * 50));
                                continue;
                        }

                    }
                    getLine = reader.ReadLine();
                    currentLine++;
                }
            }
            //for (int i = 0; i < 20; i++)
            //{
            //    bool isRock = false;
            //    for (int k = 0; k < 2; k++)
            //    {
            //        if (isRock)
            //        {
            //            this.Tiles.Add(new Tile("rock_tile", new Vector2(i*50, k*50)));
            //            isRock = false;
            //        }
            //        else
            //        {
            //            this.Tiles.Add(new Tile("grass_tile", new Vector2(i * 50, k * 50)));
            //            isRock = true;
            //        }
            //    }
            //}
        }
        
         
    }
}