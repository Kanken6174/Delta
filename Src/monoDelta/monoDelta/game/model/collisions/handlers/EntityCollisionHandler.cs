
using game.model.entity;
using game.model.entity.projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.collisions.handlers{
    public static class EntityCollisionHandler {

        /// <summary>
        /// @param entity
        /// </summary>
        public static bool IsInCollision(GameEntity p,GameEntity entity) {
            double xdistance = p.position.xpos-entity.position.xpos;
            double ydistance = p.position.ypos-entity.position.ypos;
            double absDistance = Math.Sqrt((xdistance*xdistance) + (ydistance* ydistance));

            return (absDistance < p.hitbox.radius+entity.hitbox.radius);
        }
    }
}