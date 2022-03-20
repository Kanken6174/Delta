
using Game.Model.Entity.Projectiles;

namespace Game.Model.Weapons
{
    public class Minigun : Gun
    {

        public Minigun(Projectile bullet) : base(bullet)
        {
            FireRate = 50;
        }

        public override void ReArmDefault(Microsoft.Xna.Framework.Game game)
        {
            Bullet = new SmallProjectile(game);
        }
    }
}