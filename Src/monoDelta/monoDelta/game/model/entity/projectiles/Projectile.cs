
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.entity.projectiles{
    /// <summary>
    /// A projectile is a specific type of entity that is "shot" through a Gun object. Its position object will define it's initila velocity and other parameters.
    /// </summary>
    public abstract class Projectile : Entity , ProjectilePrototype {

        /// <summary>
        /// A projectile is a specific type of entity that is "shot" through a Gun object. Its position object will define it's initila velocity and other parameters.
        /// </summary>
        public Projectile() {
        }

        public ProjectilePrototype clone()
        {
            throw new NotImplementedException();
        }
    }
}