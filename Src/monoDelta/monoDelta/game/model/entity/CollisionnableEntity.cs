using Game.Model.Collisions.Hitboxes;
using Game.Model.Entity;
using Game.Model.movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
