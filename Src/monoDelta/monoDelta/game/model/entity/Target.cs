
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monoDelta.Game.Model.Entity;
using monoDelta.Game.Model.Levels;

namespace Game.Model.Entity
{
    /// <summary>
    /// This GameEntity represents a target which the player has to hit with a projectile in order to destroy it and earn 10 points.
    /// If a target gets within 3 game units of the player they will explode, and damage the player.
    /// </summary>
    public class Target : CollisionnableEntity

    {

        public Target(Microsoft.Xna.Framework.Game game) : base(game)
        {
            LoadContent();
            this.position.ZVelocity = LevelManager.CurrentLevel.TargetSpeed;
            this.position.Zpos = LevelManager.CurrentLevel.StartTargetZ;
            this.hitbox.Radius = 0.05;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            float toScale = 0;

            Color color = Color.White;
            if (this.position.Zpos < 5)
                color = Color.Orange;

            if (this.position.Zpos > 0)
                toScale = ((float)(1 / this.position.Zpos));
            else
                toScale = 0;

            spriteBatch.Draw(texture,
            new Vector2((float)(position.Xpos), (float)position.Ypos),
            null,
            color,
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