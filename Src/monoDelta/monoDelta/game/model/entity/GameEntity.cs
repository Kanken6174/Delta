
using Game.Model.Collisions.hitboxes;
using Game.Model.movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.entity{
    public abstract class GameEntity : DrawableGameComponent{

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

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}