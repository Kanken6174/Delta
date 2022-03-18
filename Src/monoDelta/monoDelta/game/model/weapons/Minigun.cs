
using Game.Model.Entity.Projectiles;

namespace Game.Model.Weapons
{
    public class Minigun : Gun
    {

        public Minigun(Projectile bullet) : base(bullet)
        {
        }

        public Minigun()
        {
        }

#pragma warning disable CS0414 // Le champ 'Minigun.munitions' est assigné, mais sa valeur n'est jamais utilisée
        private int munitions = 200;
#pragma warning restore CS0414 // Le champ 'Minigun.munitions' est assigné, mais sa valeur n'est jamais utilisée

        public override void ReArmDefault(Microsoft.Xna.Framework.Game game)
        {
            Bullet = new SmallProjectile(game);
        }
    }
}