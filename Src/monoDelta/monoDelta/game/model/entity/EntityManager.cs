using Game.Model.Collisions.Handlers;
using Game.Model.Entity;
using Game.Model.Entity.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDelta.Game.Model.Entity
{
    public static class EntityManager
    {
        private static readonly List<GameEntity> entities = new List<GameEntity>();

        private static readonly List<Projectile> projectiles = new List<Projectile>();

        private static Crosshair crosshair;

        private static Random randomiser = new Random();

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


        public static void ProcessNextFrame(GameTime gameTime, SpriteBatch spriteBatch)
        {
            int nbelem = 0;
            while (nbelem < entities.Count)
            {
                entities[nbelem].Move();
                if(entities[nbelem].Lifetime == 0 )
                    entities.RemoveAt(nbelem);
                else
                    entities[nbelem].Draw(gameTime, spriteBatch);
                nbelem++;
            }
            crosshair.Move();
            crosshair.Draw(gameTime, spriteBatch);  //pas besoin de la bouger ici
        }

        public static void AddRandomTarget(Microsoft.Xna.Framework.Game game)
        {
            Target newtarget = new Target(game);
            int tries = 0;
            do
            {
                newtarget.position.Xpos = randomiser.Next(50, 1100);
                newtarget.position.Ypos = randomiser.Next(50, 400);
                newtarget.Lifetime = randomiser.Next(50, 1000);
                tries++;
                if (tries > 100)
                    return;
            } while (Overlaps(newtarget));
                EntityManager.AddEntity(newtarget);
        }

        private static bool Overlaps(GameEntity g)
        {
            foreach(GameEntity entity in entities)
            {
                if (EntityCollisionHandler.IsInCollision(g, entity))
                    return true;
            }
            return false;
        }
    }
}
