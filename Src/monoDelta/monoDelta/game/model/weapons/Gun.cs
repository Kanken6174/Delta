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
        public int PowerLevel { get; protected set; } = 0;
        public int Munitions { get; set; } = 0;

        public int Spread { get; set; } = 100;  //weapon spread, it defines the maximum amount of deviation when firing a projectile on the X and Y axis
        public int FireRate { get; set; } = 200;    //firing delay - a higher delay means slower rate of fire, in milliseconds

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
        /// will shoot a projectile by cloning the currently chambered projectile if the firing delay is met
        /// </summary>
        /// <param name="gameTime">the current game timer</param>
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

        /// <summary>
        /// This method is used to replace the current projectile of the weapon
        /// </summary>
        /// <param name="bullet"></param>
        public void ReArm(Projectile bullet)
        {
            Bullet = bullet;
        }
        /// <summary>
        /// This repalces the currently chambered projectile by the default one for this weapon
        /// </summary>
        /// <param name="game"></param>
        public virtual void ReArmDefault(Microsoft.Xna.Framework.Game game) {
            Bullet = new SmallProjectile(game);
        }

        public bool hasBullet() => Bullet != null;
    }
}