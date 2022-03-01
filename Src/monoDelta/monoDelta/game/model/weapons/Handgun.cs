
using Game.Model.Entity.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Weapons{
    public class Handgun : Gun {

        public Handgun(Microsoft.Xna.Framework.Game game, Projectile bullet) : base(game, bullet)
        {
        }

        private int munitions = 12;

    }
}