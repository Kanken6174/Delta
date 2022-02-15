
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monoDelta.Game.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Entity{
    public class Crosshair : CollisionnableEntity
    {

        public Crosshair(Microsoft.Xna.Framework.Game game) : base(game)
        {
            LoadContent();
            this.position.RotationVelocity = 0.1;
        }

        public int type;

        public string color;

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, 
                new Vector2((float)(position.Xpos+400), (float)position.Ypos+400), 
                null, 
                Color.White,
                (float)position.Rotation, //rotation
                new Vector2(this.texture.Width/2,this.texture.Height/2), //Origin 
                new Vector2(0.1f,0.1f),   //scale
                SpriteEffects.None, 
                0);
        }

        protected override void LoadContent()
        {
            this.texture = Game.Content.Load<Texture2D>("Art/crs");
        }

        public override void Move()
        {
            this.position.Rotation += this.position.RotationVelocity;
            //rien, la crosshair est bougée par le kinectManager
        }
    }
}