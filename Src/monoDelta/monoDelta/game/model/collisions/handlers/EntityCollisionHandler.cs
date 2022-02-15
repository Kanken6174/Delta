
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

        public static bool hasProjectileCollidedWith(Projectile p, GameEntity entity)
        {
            double xdistance = p.position.Xpos - entity.position.Xpos;
            double ydistance = p.position.Ypos - entity.position.Ypos;
            double absDistance = Math.Sqrt((xdistance * xdistance) + (ydistance * ydistance));
            if (absDistance > ((p.hitbox.Radius + entity.hitbox.Radius))*2)
                return false;   //le projectile n'est pas sur l'axe de la cible

            double zVelocityA = entity.position.ZVelocity;
            double zVelocityB = p.position.ZVelocity;
            double zDistance = p.position.Zpos - entity.position.Zpos;  //la distance entre les deux points actuels des entités

            return (zDistance < (p.hitbox.Radius + entity.hitbox.Radius + Math.Abs(zVelocityA) +Math.Abs(zVelocityB)));

        }

    }
}