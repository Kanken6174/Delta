
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

        private int munitions = 12;

        public override void ReArmDefault(Microsoft.Xna.Framework.Game game)
        {
            Bullet = new SmallProjectile(game);
        }
    }
}