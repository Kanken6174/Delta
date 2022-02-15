
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monoDelta.Game.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Entity
{
    public class Target : CollisionnableEntity

    {

        public Target(Microsoft.Xna.Framework.Game game) : base(game)
        {
            LoadContent();
            this.position.ZVelocity = -0.005;
            this.position.Zpos = 10;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            float toScale = 0;

            if (this.position.Zpos > 0)
                toScale = ((float)(1/this.position.Zpos));
            else
                toScale = 0;

            spriteBatch.Draw(texture,
            new Vector2((float)(position.Xpos), (float)position.Ypos),
            null,
            Color.White,
            0, //rotation 
            new Vector2(this.texture.Width / 2, this.texture.Height / 2), //Origin
            new Vector2(toScale, toScale),   //scale
            SpriteEffects.None,
            0) ;
        }

        protected override void LoadContent()
        {
            this.texture = Game.Content.Load<Texture2D>("Art/target");
            this.hitbox.Radius = texture.Width / 22;
        }
    }
}