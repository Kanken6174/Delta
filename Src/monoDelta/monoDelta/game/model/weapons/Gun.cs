
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Weapons{
    /// <summary>
    /// A gun object is used to "shoot" Projectile entities by cloning said entity and placing it at the spot designated by the Crosshair entity.
    /// </summary>
    public abstract class Gun {

        /// <summary>
        /// A gun object is used to "shoot" Projectile entities by cloning said entity and placing it at the spot designated by the Crosshair entity.
        /// </summary>
        public Gun() {
        }

        private int munitions = 0;

        private int reloadTime = 0;

        public int spread;

        public int fireRate;



        public void Shoot() {
            // TODO implement here
        }

    }
}