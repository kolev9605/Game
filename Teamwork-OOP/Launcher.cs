using System;

namespace Teamwork_OOP
{
    public static class Launcher
    {
        [STAThread]
        static void Main()
        {
            //TODO GO THROUGH ALL TODOS AT END OF DEVELOPMENT
            using (var game = new Engine.Engine())
                game.Run();
        }
    }
}