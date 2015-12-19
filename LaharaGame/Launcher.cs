namespace LaharaGame
{
    using System;
    using Factories;
    using GameObjects.Map;
    using Interfaces;

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