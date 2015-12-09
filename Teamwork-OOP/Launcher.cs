using System;

namespace Teamwork_OOP
{
    public static class Launcher
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Engine.Engine())
                game.Run();
        }
    }
}