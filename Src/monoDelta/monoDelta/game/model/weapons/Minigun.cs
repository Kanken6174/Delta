
using Game.Model.Entity.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Weapons{
    public class Minigun : Gun {

        public Minigun(Projectile bullet) : base(bullet)
        {
        }

        public Minigun()
        {
        }

        private int munitions = 200;

        public void ReArmDefault(Microsoft.Xna.Framework.Game game)
        {
            Bullet = new SmallProjectile(game);
        }
    }
}