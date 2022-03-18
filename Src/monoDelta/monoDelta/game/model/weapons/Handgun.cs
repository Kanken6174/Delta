
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

#pragma warning disable CS0414 // Le champ 'Handgun.munitions' est assigné, mais sa valeur n'est jamais utilisée
        private int munitions = 12;
#pragma warning restore CS0414 // Le champ 'Handgun.munitions' est assigné, mais sa valeur n'est jamais utilisée

        public override void ReArmDefault(Microsoft.Xna.Framework.Game game)
        {
            Bullet = new SmallProjectile(game);
        }
    }
}