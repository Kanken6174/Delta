using Game.Model.Entity;
using Game.Model.Entity.Projectiles;
using Microsoft.Xna.Framework;
using MonoDelta.Game.Model.Entity;
using System;
using System.Text.Json.Serialization;

namespace Game.Model.Weapons
{
    /// <summary>
    /// A gun object is used to "shoot" Projectile entities by cloning said entity and placing it at the spot designated by the Crosshair entity.
    /// </summary>
    public class Gun
    {

        protected Random random = new Random();

        protected Projectile Bullet;
       
        public int Spread { get; set; } = 100;
        public int FireRate { get; set; } = 200;

        public double lastFired = 0;

        /// <summary>
        /// A gun object is used to "shoot" Projectile entities by cloning said entity and placing it at the spot designated by the Crosshair entity.
        /// </summary>
        public Gun(Projectile bullet)
        {
            ReArm(bullet);
        }

        [JsonConstructor]
        public Gun()
        {
            Bullet = null;
        }

        /// <summary>
        /// Va tirer une balle en clonant Bullet à un certain intervalle
        /// </summary>
        /// <param name="gameTime">Le temps actuel du jeu</param>
        public virtual void Shoot(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds - lastFired > FireRate)
            {
                foreach (Crosshair cr in EntityManager.GetCrosshairs())
                {
                    Projectile bullet = this.Bullet.Clone();
                    bullet.position.Xpos = cr.position.Xpos + (float)random.Next(-Spread, Spread) / 10;
                    bullet.position.Ypos = cr.position.Ypos + (float)random.Next(-Spread, Spread) / 10;

                    bullet.position.XVelocity = (float)random.Next(-Spread, Spread) / 100;
                    bullet.position.YVelocity = (float)random.Next(-Spread, Spread) / 100;

                    bullet.position.Zpos = 0;
                    EntityManager.AddProjectile(bullet);
                    lastFired = gameTime.TotalGameTime.TotalMilliseconds;
                }
            }
        }

        //Va remplacer la balle actuelle de l'arme
        public void ReArm(Projectile bullet)
        {
            Bullet = bullet;
        }

        public virtual void ReArmDefault(Microsoft.Xna.Framework.Game game) {
            Bullet = new SmallProjectile(game);
        }

        public bool hasBullet() => Bullet != null;
    }
}