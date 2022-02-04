
using game.model.collisions.hitboxes;
using game.model.movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.entity{
    public abstract class Entity {

        public Entity() {
        }

        public int Lifetime;

        public Position position;

        public HitboxSphere hitbox;

        public Texture2D texture;

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}