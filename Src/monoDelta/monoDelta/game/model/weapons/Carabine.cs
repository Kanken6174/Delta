
using Game.Model.Entity.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Weapons{
    public class Carabine : Gun {

        public Carabine(Projectile bullet) : base(bullet)
        {
        }

        private int munitions = 20;

    }
}