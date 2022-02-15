
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
        public Projectile Clone()
        {
            Projectile bullet = (Projectile)this.MemberwiseClone();
            bullet.Lifetime = 100;
            bullet.position = new Position();
            bullet.position.ZVelocity = 0.005;
            bullet.position.RotationVelocity = 1;
            bullet.texture = this.texture;
            return bullet;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            float toScale = 0;

            if (this.position.Zpos > 0)
                toScale = ((float)(1 / this.position.Zpos));
            else
                toScale = 0;

            spriteBatch.Draw(texture,
            new Vector2((float)(position.Xpos), (float)position.Ypos),
            null,
            Color.Black,
            0, //rotation 
            new Vector2(this.texture.Width / 2, this.texture.Height / 2), //Origin
            new Vector2(toScale, toScale),   //scale
            SpriteEffects.None,
            0);
        }

        protected override void LoadContent()
        {
            this.texture = Game.Content.Load<Texture2D>("Art/target");
            this.hitbox.Radius = texture.Width / 22;
        }
    }
}