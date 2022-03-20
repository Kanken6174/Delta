
using Game.Model.Entity;
using Game.Model.Entity.Projectiles;
using System;

namespace Game.Model.Collisions.Handlers
{
    /// <summary>
    /// The EntityCollisionHandler is used to check for collisions between spherical hitboxes in a 3d plane
    /// </summary>
    public static class EntityCollisionHandler
    {

        /// <summary>
        /// this method will check if 2 GameEntity are in collision on the 2d plane (xy)
        /// </summary>
        /// <param name="p">first entity</param>
        /// <param name="entity">second entity</param>
        /// <returns></returns>
        public static bool IsInCollision(GameEntity p, GameEntity entity)
        {
            double xdistance = p.position.Xpos - entity.position.Xpos;
            double ydistance = p.position.Ypos - entity.position.Ypos;
            double absDistance = Math.Sqrt((xdistance * xdistance) + (ydistance * ydistance));

            return (absDistance < p.hitbox.Radius + entity.hitbox.Radius);
        }

        /// <summary>
        /// this method checks for collision between a bullet and a gameEntity on the 3d plane (xyz)
        /// </summary>
        /// <param name="p">projectile to check for collisions (the path that the projectile took to hit the </param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool HasProjectileCollidedWith(Projectile p, GameEntity entity)
        {
            double xdistance = p.position.Xpos - entity.position.Xpos;
            double ydistance = p.position.Ypos - entity.position.Ypos;
            double absDistance = Math.Sqrt((xdistance * xdistance) + (ydistance * ydistance));
            if (absDistance > ((p.hitbox.Radius + entity.hitbox.Radius)) * 2)
                return false;   //projectile isn't on the target's 2d axis

            double zVelocityA = entity.position.ZVelocity;
            double zVelocityB = p.position.ZVelocity;
            double zDistance = p.position.Zpos - entity.position.Zpos;

            return (zDistance < (p.hitbox.Radius + entity.hitbox.Radius + Math.Abs(zVelocityA) + Math.Abs(zVelocityB)));

        }

    }
}