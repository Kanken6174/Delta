
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.entity{
    public class Crosshair : GameEntity {

        public Crosshair(Game game) : base(game)
        {

        }

        public int type;

        public string color;

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, 
                new Vector2((float)(position.xpos+400), (float)position.ypos+400), 
                null, 
                Color.White,
                0, //rotation 
                new Vector2(0,0), //Origin 
                new Vector2(0.1f,0.1f),   //scale
                SpriteEffects.None, 
                0);
        }
    }
}