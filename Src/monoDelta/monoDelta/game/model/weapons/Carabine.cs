
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

#pragma warning disable CS0414 // Le champ 'Carabine.munitions' est assign�, mais sa valeur n'est jamais utilis�e
        private int munitions = 20;
#pragma warning restore CS0414 // Le champ 'Carabine.munitions' est assign�, mais sa valeur n'est jamais utilis�e

        public override void ReArmDefault(Microsoft.Xna.Framework.Game game)
        {
            Bullet = new SmallProjectile(game);
        }
    }
}