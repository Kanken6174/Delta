
using Game.Model.Collisions.Hitboxes;
using Game.Model.movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monoDelta.Game.Model.Entity;
using monoDelta.Game.Model.Levels;

namespace Game.Model.Entity.Projectiles
{
    /// <summary>
    /// A projectile is a specific type of entity that is "shot" through a Gun object. Its position object will define it's initila velocity and other parameters.
    /// </summary>
    public abstract class Projectile : CollisionnableEntity

    , IProjectilePrototype
    {

        public Projectile(Microsoft.Xna.Framework.Game game) : base(game)
        {
            position = new Position();
            Lifetime = 1000;
            hitbox = new HitboxSphere
            {
                Radius = 10
            };
            this.position.ZVelocity = 0.005;
            this.position.RotationVelocity = 1;
        }

        /// <summary>
        /// A projectile is a specific type of entity that is "shot" through a Gun object. Its position object will define it's initila velocity and other parameters.
        /// </summary>
        public Projectile Clone()
        {
            Projectile bullet = new SmallProjectile(base.Game)
            {
                position = new Position()
            };
            bullet.position.Xpos = this.position.Xpos;
            bullet.position.Ypos = this.position.Ypos;
            bullet.position.Zpos = this.position.Zpos;
            bullet.position.XVelocity = this.position.XVelocity;
            bullet.position.YVelocity = this.position.YVelocity;
            bullet.position.ZVelocity = this.position.ZVelocity;
            bullet.position.Rotation = this.position.Rotation;
            bullet.position.RotationVelocity = this.position.RotationVelocity;
            bullet.Lifetime = 100;
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

        public override void Move()
        {
            if (this.Lifetime > -1)
            {
                this.Lifetime--;
            }
            this.position.Rotation += this.position.RotationVelocity;
            this.position.Xpos += this.position.XVelocity;
            this.position.Ypos += this.position.YVelocity;
            this.position.Zpos += this.position.ZVelocity;

            this.position.XVelocity -= LevelManager.CurrentLevel.Gravity;
            this.position.YVelocity += LevelManager.CurrentLevel.Wind;


    }

        protected override void LoadContent()
        {
            this.texture = Game.Content.Load<Texture2D>("Art/target");
            this.hitbox.Radius = texture.Width / 22;
        }
    }
}