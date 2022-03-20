using Game.Model.Collisions.Hitboxes;
using Game.Model.Entity;
using Game.Model.movement;

namespace monoDelta.Game.Model.Entity
{
    /// <summary>
    /// Describes an Entity that has a hitbox of its own and can be collided with.
    /// </summary>
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
