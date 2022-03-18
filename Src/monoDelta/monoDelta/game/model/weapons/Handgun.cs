
using Game.Model.Entity.Projectiles;
using System.Text.Json.Serialization;

namespace Game.Model.Weapons
{
    public class Handgun : Gun
    {

        public Handgun(Projectile bullet) : base(bullet)
        {
        }

        [JsonConstructor]
        public Handgun() { }

#pragma warning disable CS0414 // Le champ 'Handgun.munitions' est assign�, mais sa valeur n'est jamais utilis�e
        private int munitions = 12;
#pragma warning restore CS0414 // Le champ 'Handgun.munitions' est assign�, mais sa valeur n'est jamais utilis�e

        public override void ReArmDefault(Microsoft.Xna.Framework.Game game)
        {
            Bullet = new SmallProjectile(game);
        }
    }
}