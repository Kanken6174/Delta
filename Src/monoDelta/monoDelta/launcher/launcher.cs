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
            using (Game.GameController game = new Game.GameController())
                game.Run();
        }
    }
}
