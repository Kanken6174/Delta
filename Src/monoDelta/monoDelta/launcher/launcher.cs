using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoDelta.launcher
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new game.GameController())
                game.Run();
        }
    }
}
