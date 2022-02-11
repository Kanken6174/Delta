
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Entity.Projectiles{
    /// <summary>
    /// A projectile is a specific type of entity that is "shot" through a Gun object. Its position object will define it's initila velocity and other parameters.
    /// </summary>
    public abstract class Projectile : GameEntity , IProjectilePrototype {

        public Projectile(Microsoft.Xna.Framework.Game game) : base(game)
        {

        }

        /// <summary>
        /// A projectile is a specific type of entity that is "shot" through a Gun object. Its position object will define it's initila velocity and other parameters.
        /// </summary>
        public IProjectilePrototype Clone()
        {
            return (IProjectilePrototype)this.MemberwiseClone();
        }
    }
}