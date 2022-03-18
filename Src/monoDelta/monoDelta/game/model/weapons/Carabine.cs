
using Game.Model.Entity.Projectiles;

namespace Game.Model.Weapons
{
    public class Carabine : Gun
    {

        public Carabine(Projectile bullet) : base(bullet)
        {
        }

        public Carabine()
        {
        }

        private int munitions = 20;

        public override void ReArmDefault(Microsoft.Xna.Framework.Game game)
        {
            Bullet = new SmallProjectile(game);
        }
    }
}