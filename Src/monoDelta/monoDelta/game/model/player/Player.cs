
using Game.Model.Weapons;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Player
{
    public class Player {

        public Player(Microsoft.Xna.Framework.Game game)
        {
            gun = new Handgun(game);
        }

        public int Munitions { get; private set; }

        public int Life { get; private set; }

        public int Score { get; private set; }

        public Gun gun { get; private set; }

        public void Update(GameTime time)
        {
            gun.Shoot(time);
        }

    }
}