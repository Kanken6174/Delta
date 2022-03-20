
using Game.Model.Collisions.Hitboxes;
using Game.Model.movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Model.Entity
{
    /// <summary>
    /// A GameEntity is a graphical entity that can be moved around the playspace and drawn. Every Entity used in this project share the same base class.
    /// </summary>
    public abstract class GameEntity : DrawableGameComponent
    {

        public GameEntity(Microsoft.Xna.Framework.Game game) : base(game)
        {
            position = new Position();
            Lifetime = -1;
            hitbox = new HitboxSphere();
        }

        public int Lifetime;

        public Position position;

        public HitboxSphere hitbox;

        public Texture2D texture;

        /// <summary>
        /// This method enables each gameEntity to draw itself when provided witht eh correct arguments.
        /// </summary>
        /// <param name="gameTime">the main game timer</param>
        /// <param name="spriteBatch">the game's sprite drawer helper</param>
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        /// <summary>
        /// This method is used to let a gameEntity apply its acceleration to its position and as such move itself. Some subclasses may override this method
        /// to add customized logic to their movement.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Move(GameTime gameTime)
        {
            if (this.Lifetime > -1)
            {
                this.Lifetime--;
            }
            this.position.Rotation += this.position.RotationVelocity;
            this.position.Xpos += this.position.XVelocity;
            this.position.Ypos += this.position.YVelocity;
            this.position.Zpos += this.position.ZVelocity;

        }
    }
}