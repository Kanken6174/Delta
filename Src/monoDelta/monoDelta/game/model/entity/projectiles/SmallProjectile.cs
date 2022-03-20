
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game.Model.Entity.Projectiles
{
    /// <summary>
    /// Describes a smaller version of the abstract projectile, used as the default projectile in this project
    /// </summary>
    public class SmallProjectile : Projectile
    {

        public SmallProjectile(Microsoft.Xna.Framework.Game game) : base(game)
        {
            this.position.Zpos = 0;
            this.hitbox.Radius = 0.01;
            this.position.ZVelocity = 0.1;
            this.position.RotationVelocity = 1;
            LoadContent();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            float toScale = 0.1f;

            if (this.position.Zpos > 0)
                toScale = ((float)(1 / this.position.Zpos)) * 10;
            else
                toScale = 0;

            double test = this.position.ZVelocity;
            spriteBatch.Draw(texture,
            new Vector2((float)position.Xpos, (float)position.Ypos),
            null,
            Color.White,
            0, //rotation 
            new Vector2(this.texture.Width / 2, this.texture.Height / 2), //Origin
            new Vector2((float)(Math.Sqrt(toScale)) / 100, ((float)Math.Sqrt(toScale)) / 100),   //scale
            SpriteEffects.None,
            0);
        }

        protected override void LoadContent()
        {
            this.texture = Game.Content.Load<Texture2D>("Art/bullet");
            this.hitbox.Radius = texture.Width / 22;
        }
    }
}