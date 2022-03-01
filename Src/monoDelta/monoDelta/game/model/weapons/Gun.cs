
using Game.Model.Entity;
using Game.Model.Entity.Projectiles;
using Microsoft.Xna.Framework;
using MonoDelta.Game.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Weapons{
    /// <summary>
    /// A gun object is used to "shoot" Projectile entities by cloning said entity and placing it at the spot designated by the Crosshair entity.
    /// </summary>
    public abstract class Gun {

        private int munitions = 0;

        private int reloadTime = 0;

        public int spread = 100;

        private Random random = new Random();

        public int fireRate = 100;

        public Projectile Bullet { get; private set; }

        public double lastFired = 0;

        /// <summary>
        /// A gun object is used to "shoot" Projectile entities by cloning said entity and placing it at the spot designated by the Crosshair entity.
        /// </summary>
        public Gun(Microsoft.Xna.Framework.Game game, Projectile bullet) {
            Bullet = new SmallProjectile(game);
        }

        public void Shoot(GameTime gameTime) {
            if (gameTime.TotalGameTime.TotalMilliseconds - lastFired > fireRate)
            {
                Projectile bullet = this.Bullet.Clone();
                bullet.position.Xpos = EntityManager.GetCrosshair().position.Xpos + (float)random.Next(-spread,spread)/10;
                bullet.position.Ypos = EntityManager.GetCrosshair().position.Ypos + (float)random.Next(-spread, spread) / 10;
                EntityManager.AddProjectile(bullet);
                lastFired = gameTime.TotalGameTime.TotalMilliseconds;
            }
        }

    }
}