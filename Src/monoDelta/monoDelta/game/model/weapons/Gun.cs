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

        [JsonIgnore]
        public Projectile Bullet { get; protected set; }
        public int PowerLevel { get; protected set; } = 0;
        public int Munitions { get; set; } = 0;
        public int Spread { get; set; } = 100;
        public int FireRate { get; set; } = 50;

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
                Projectile bullet = this.Bullet.Clone();
                bullet.position.Xpos = EntityManager.GetCrosshair().position.Xpos + (float)random.Next(-Spread, Spread) / 10;
                bullet.position.Ypos = EntityManager.GetCrosshair().position.Ypos + (float)random.Next(-Spread, Spread) / 10;

                bullet.position.XVelocity = (float)random.Next(-Spread, Spread) / 100;
                bullet.position.YVelocity = (float)random.Next(-Spread, Spread) / 100;

                bullet.position.Zpos = 0;
                EntityManager.AddProjectile(bullet);
                lastFired = gameTime.TotalGameTime.TotalMilliseconds;
            }
        }

        //Va remplacer la balle actuelle de l'arme
        public void ReArm(Projectile bullet)
        {
            Bullet = bullet;
        }

        public virtual void ReArmDefault(Microsoft.Xna.Framework.Game game) { 
            
        }
    }
}