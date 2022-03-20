
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monoDelta.Game.Model.Entity;

namespace Game.Model.Entity
{
    /// <summary>
    /// The crosshair is a specific type of CollisionnableEntity that serves as ... crosshair for the player to aim.
    /// its position is set by the kinectManager and whenever a projectile is cloned it will place itself on one or more crosshairs (depending on how
    /// many players there are)
    /// </summary>
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
                new Vector2((float)(position.Xpos), (float)position.Ypos),
                null,
                Color.White,
                (float)position.Rotation, //rotation
                new Vector2(this.texture.Width / 2, this.texture.Height / 2), //Origin 
                new Vector2(0.1f, 0.1f),   //scale
                SpriteEffects.None,
                0);
        }

        protected override void LoadContent()
        {
            this.texture = Game.Content.Load<Texture2D>("Art/crs");
        }

        public override void Move(GameTime gameTime)
        {
            this.position.Rotation += this.position.RotationVelocity;
            //the crosshair is moved by the KinectManager
        }
    }
}