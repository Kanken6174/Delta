
using Game.Model.Entity;
using Game.Model.Entity.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Collisions.Handlers{
    public static class EntityCollisionHandler {

        /// <summary>
        /// @param entity
        /// </summary>
        public static bool IsInCollision(GameEntity p,GameEntity entity) {
            double xdistance = p.position.Xpos-entity.position.Xpos;
            double ydistance = p.position.Ypos-entity.position.Ypos;
            double absDistance = Math.Sqrt((xdistance*xdistance) + (ydistance* ydistance));

            return (absDistance < p.hitbox.Radius+entity.hitbox.Radius);
        }

    }
}