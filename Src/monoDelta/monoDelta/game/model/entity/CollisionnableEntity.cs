using Game.Model.Collisions.Hitboxes;
using Game.Model.Entity;
using Game.Model.movement;

namespace monoDelta.Game.Model.Entity
{
    public abstract class CollisionnableEntity : GameEntity
    {
        public CollisionnableEntity(Microsoft.Xna.Framework.Game game) : base(game)
        {
            position = new Position();
            Lifetime = -1;
            hitbox = new HitboxSphere();
        }

    }
}
