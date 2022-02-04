using game.model.entity;
using game.model.entity.projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoDelta.game.model.entity
{
    public static class EntityManager
    {
        private static List<GameEntity> entities = new List<GameEntity>();

        private static List<Projectile> projectiles = new List<Projectile>();

        private static Crosshair crosshair;

        public static void AddEntity(GameEntity e)
        {
            entities.Add(e);
        }

        public static List<Projectile> GetProjectiles()
        {
            return projectiles;
        }

        public static void AddProjectile(Projectile e)
        {
            projectiles.Add(e);
        }

        public static List<GameEntity> GetEntities()
        {
            return entities;
        }

        public static Crosshair GetCrosshair()
        {
            return crosshair;
        }

        public static void SetCrosshair(Crosshair c)
        {
            crosshair = c;
        }

        public static void DrawAll(GameTime gameTime, SpriteBatch spriteBatch)
        {
            crosshair.Draw(gameTime, spriteBatch);
            foreach(GameEntity e in entities)
            {
                e.Draw(gameTime, spriteBatch);
            }
        }
    }
}
