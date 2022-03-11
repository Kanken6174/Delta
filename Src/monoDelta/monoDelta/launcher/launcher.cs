using monoDelta.Game.Model.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDelta.launcher
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            LevelManager.serializeCurrentLevel();
            using (Game.GameController game = new Game.GameController())
                game.Run();
        }
    }
}
