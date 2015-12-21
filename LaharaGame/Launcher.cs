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
            //при разчиатенто на мапа да сложа енемитата в dictionary
            //da se podava tozi dictionary na attack v player.cs v metod Act
            //kogato nqkoi hitva drug, da mu vika     
            //public void UpdateHealthBar()
           // {
          //      healthBar = new Rectangle((int)this.Position.X, (int)this.Position.Y, this.TextureWidth, this.TextureHeight);
           // }
        }
    }
}