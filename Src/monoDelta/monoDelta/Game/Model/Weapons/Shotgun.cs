
using Game.Model.Entity.Projectiles;
using Microsoft.Xna.Framework;
using MonoDelta.Game.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Weapons
{
    public class Shotgun : Gun
    {

        public Shotgun(Microsoft.Xna.Framework.Game game, Projectile bullet) : base(game, bullet)
        {
            this.fireRate = 800;
            this.spread = 50;
        }

        private int munitions = 12;



        public override void Shoot(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds - lastFired > fireRate)
            {
                for (int i = 0; i < 6; i++)
                {
                    Projectile bullet = this.Bullet.Clone();
                    bullet.position.Xpos = EntityManager.GetCrosshair().position.Xpos + (float)random.Next(-spread, spread) / 10;
                    bullet.position.Ypos = EntityManager.GetCrosshair().position.Ypos + (float)random.Next(-spread, spread) / 10;

                    bullet.position.XVelocity = (float)random.Next(-spread, spread) / 200;
                    bullet.position.YVelocity = (float)random.Next(-spread, spread) / 200;

                    bullet.position.Zpos = 0;
                    EntityManager.AddProjectile(bullet);
                    lastFired = gameTime.TotalGameTime.TotalMilliseconds;
                }
            }
        }

    }
}