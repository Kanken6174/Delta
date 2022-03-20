using System;

namespace MonoDelta.launcher
{
    /// <summary>
    /// Ceci est le point d'entrée du jeu, il est responsable du lancement de monogame.
    /// </summary>
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
