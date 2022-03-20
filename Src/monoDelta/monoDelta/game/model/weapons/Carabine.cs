
using Game.Model.Entity.Projectiles;

namespace Game.Model.Weapons
{
    public class Carabine : Gun
    {

        public Carabine(Projectile bullet) : base(bullet)
        {
            FireRate = 100;
        }

        public override void ReArmDefault(Microsoft.Xna.Framework.Game game)
        {
            Bullet = new SmallProjectile(game);
        }
    }
}