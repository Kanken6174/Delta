
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.entity
{
    public class Target : GameEntity
    {

        public Target(Microsoft.Xna.Framework.Game game) : base(game)
        {
            LoadContent();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,
            new Vector2((float)(position.Xpos), (float)position.Ypos),
            null,
            Color.White,
            0, //rotation 
            new Vector2(0, 0), //Origin 
            new Vector2((float)(0.1f *this.position.Zpos), (float)(0.1f * this.position.Zpos)),   //scale
            SpriteEffects.None,
            0);
        }

        protected override void LoadContent()
        {
            this.texture = Game.Content.Load<Texture2D>("Art/target");
            this.hitbox.radius = texture.Width / 22;
        }
    }
}