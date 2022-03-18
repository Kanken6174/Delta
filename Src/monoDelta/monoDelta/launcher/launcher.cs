using System;

namespace MonoDelta.launcher
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (Game.GameController game = new Game.GameController())
                game.Run();
        }
    }
}
