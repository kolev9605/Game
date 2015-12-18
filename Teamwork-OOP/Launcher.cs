using System;
using Teamwork_OOP.Factories;
using Teamwork_OOP.GameObjects.Map;
using Teamwork_OOP.Interfaces;

namespace Teamwork_OOP
{
    public static class Launcher
    {
        [STAThread]
        static void Main()
        {
            IMap map = new Map("../../../Content/Levels/Level1.txt", 50, 50);
            IMapFactory mapFactory = new MapFactory();
            ITileFactory tileFactory = new TileFactory();

            //TODO GO THROUGH ALL TODOS AT END OF DEVELOPMENT
            using (var game = new Engine.Engine(map,mapFactory,tileFactory))
                game.Run();
        }
    }
}