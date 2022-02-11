
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.entity.projectiles{
    /// <summary>
    /// A projectile is a specific type of entity that is "shot" through a Gun object. Its position object will define it's initila velocity and other parameters.
    /// </summary>
    public abstract class Projectile : GameEntity , ProjectilePrototype {

        public Projectile(Microsoft.Xna.Framework.Game game) : base(game)
        {

        }

        /// <summary>
        /// A projectile is a specific type of entity that is "shot" through a Gun object. Its position object will define it's initila velocity and other parameters.
        /// </summary>
        public ProjectilePrototype clone()
        {
            throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }
    }
}