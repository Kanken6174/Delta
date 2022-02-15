﻿using Game.Model.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoDelta.Game.Model
{
    public static class PlayerManager
    {
        private static Player player;

        public static Player GetPlayer()
        {
            return player;
        }

        public static void SetPlayer(Player p)
        {
            player = p;
            
        }

    }
}
