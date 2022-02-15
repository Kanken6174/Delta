using Game.Model.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoDelta.Game.Model
{
    class PlayerManager
    {
        private Player player;

        public PlayerManager()
        {
            player = new Player();
        }

        public Player GetPlayer()
        {
            return player;
        }

        public void SetPlayer(Player p)
        {
            player = p;
            
        }

    }
}
