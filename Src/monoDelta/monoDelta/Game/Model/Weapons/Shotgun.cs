
using Game.Model.Entity;
using Game.Model.Entity.Projectiles;
using Microsoft.Xna.Framework;
using MonoDelta.Game.Model.Entity;
using System.Text.Json.Serialization;

namespace Game.Model.Weapons
{
    public class Shotgun : Gun
    {

        public Shotgun(Projectile bullet) : base(bullet)
        {
            FireRate = 200;
            this.Spread = 200;
        }



        public override void Shoot(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds - lastFired > FireRate)
            {
                for (int i = 0; i < 15; i++)
                {
                    foreach(Crosshair cr in EntityManager.GetCrosshairs())
                    {
                        Projectile bullet = this.Bullet.Clone();
                        bullet.position.Xpos = cr.position.Xpos + (float)random.Next(-Spread, Spread) / 10;
                        bullet.position.Ypos = cr.position.Ypos + (float)random.Next(-Spread, Spread) / 10;

                        bullet.position.XVelocity = (float)random.Next(-Spread, Spread) / 200;
                        bullet.position.YVelocity = (float)random.Next(-Spread, Spread) / 200;

                        EntityManager.AddProjectile(bullet);
                    }
                }
                lastFired = gameTime.TotalGameTime.TotalMilliseconds;
            }
        }

        public override void ReArmDefault(Microsoft.Xna.Framework.Game game)
        {
            Bullet = new SmallProjectile(game);
        }

    }
}