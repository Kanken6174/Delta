
using Game.Model.Collisions.Hitboxes;
using Game.Model.movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monoDelta.Game.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Entity.Projectiles{
    /// <summary>
    /// A projectile is a specific type of entity that is "shot" through a Gun object. Its position object will define it's initila velocity and other parameters.
    /// </summary>
    public abstract class Projectile : CollisionnableEntity

    , IProjectilePrototype {

        public Projectile(Microsoft.Xna.Framework.Game game) : base(game)
        {
            position = new Position();
            Lifetime = 1000;
            hitbox = new HitboxSphere();
            hitbox.Radius = 10;
        }

        /// <summary>
        /// A projectile is a specific type of entity that is "shot" through a Gun object. Its position object will define it's initila velocity and other parameters.
        /// </summary>
        public IProjectilePrototype Clone()
        {
            Projectile bullet = (Projectile)this.MemberwiseClone();
            bullet.Lifetime = 100;
            bullet.position = new Position();
            bullet.position.ZVelocity = 0.1;
            bullet.texture = this.texture;
            return bullet;
        }
    }
}