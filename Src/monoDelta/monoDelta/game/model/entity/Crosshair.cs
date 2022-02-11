
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Entity{
    public class Crosshair : GameEntity {

        public Crosshair(Microsoft.Xna.Framework.Game game) : base(game)
        {
            LoadContent();
        }

        public int type;

        public string color;

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, 
                new Vector2((float)(position.Xpos+400), (float)position.Ypos+400), 
                null, 
                Color.White,
                0, //rotation 
                new Vector2(0,0), //Origin 
                new Vector2(0.1f,0.1f),   //scale
                SpriteEffects.None, 
                0);
        }

        protected override void LoadContent()
        {
            this.texture = Game.Content.Load<Texture2D>("Art/crs");
        }
    }
}