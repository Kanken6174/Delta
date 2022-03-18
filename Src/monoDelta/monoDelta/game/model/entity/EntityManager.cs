using Game.Model.Collisions.Handlers;
using Game.Model.Entity;
using Game.Model.Entity.Projectiles;
using Game.Model.movement;
using Game.Model.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monoDelta.Game.Model;
using monoDelta.Game.Model.Entity;
using monoDelta.Game.Model.Levels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoDelta.Game.Model.Entity
{
    public static class EntityManager
    {
        private static readonly List<GameEntity> entities = new List<GameEntity>();

        private static readonly List<Projectile> projectiles = new List<Projectile>();

        private static List<Crosshair> crosshairs = new List<Crosshair>();

        private static Random randomiser = new Random();

        private static double lastSpawned = 0;

        private static Microsoft.Xna.Framework.Game game;

        private static UInt64 gametimer = 0;

        public static void Init(Microsoft.Xna.Framework.Game g) => game = g;

        public static void AddEntity(GameEntity e)
        {
            entities.Insert(0, e);
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

        public static List<Crosshair> GetCrosshairs()
        {
            return crosshairs;
        }

        public static void SetCrosshairs(List<Crosshair> c)
        {
            if(c.Count > 0)
                crosshairs = c;
        }

        public static void SetCrosshairs(List<Position> ps)
        {
            if (game == null)
                return;
            crosshairs.Clear();
            foreach(Position p in ps)
            {
                Crosshair cr = new Crosshair(game);
                cr.position = p;
                crosshairs.Add(cr);
            }
        }


        public static void ClearAll()
        {
            entities.Clear();
            projectiles.Clear();
        }

        public static void ProcessNextFrame(GameTime gameTime, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Game game)
        {
            if(gameTime.TotalGameTime.TotalMilliseconds > gametimer + 15)
                gametimer += 15;
            else
                return;

            for (int nbelem = 0; nbelem < entities.Count; nbelem++)
            {
                entities[nbelem].Move(gameTime);
                if (entities[nbelem].position.Zpos < 3)
                {
                    entities.RemoveAt(nbelem);
                    PlayerManager.GetPlayer().DecrementLife();
                }
            }

            foreach(Crosshair cr in crosshairs)
            {
                cr.Move(gameTime);
            }

            PlayerManager.GetPlayer().Update(gameTime);
            for (int nbelem = 0; nbelem < projectiles.Count && projectiles.Count > 0; nbelem++)
            {
                projectiles[nbelem].Move(gameTime);
                if (projectiles[nbelem].Lifetime == 0)
                    projectiles.RemoveAt(nbelem);
            }
            if (gameTime.TotalGameTime.TotalMilliseconds - lastSpawned > LevelManager.CurrentLevel.TargetSpawnDelay)
            {
                AddRandomTarget(game);
                lastSpawned = gameTime.TotalGameTime.TotalMilliseconds;
            }
            for (int j = 0; j < entities.Count; j++)
            {
                for (int i = 0; i < projectiles.Count; i++)
                {
                    if (j < entities.Count &&  EntityCollisionHandler.hasProjectileCollidedWith(projectiles[i], entities[j]))
                    {
                        entities.RemoveAt(j);
                        PlayerManager.GetPlayer().IncrementScore(10);
                    }
                }
            }
        }

        public static void DrawNextFrame(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (GameEntity e in entities)
            {
                e.Draw(gameTime, spriteBatch);
            }

            foreach (Projectile p in projectiles)
            {
                p.Draw(gameTime, spriteBatch);
            }

            foreach(Crosshair crosshair in crosshairs)
                crosshair.Draw(gameTime, spriteBatch);
        }

        public static void AddRandomTarget(Microsoft.Xna.Framework.Game game)
        {
            CollisionnableEntity newtarget;

            if (randomiser.Next(0, 100) / 100 > LevelManager.CurrentLevel.BonusChance && LevelManager.CurrentLevel.PossibleWeapons.Count > 0) //1/100 chances
            {
                int randomGunIndex = randomiser.Next(0, LevelManager.CurrentLevel.PossibleWeapons.Count());
                Gun gun = LevelManager.CurrentLevel.PossibleWeapons[randomGunIndex];
                newtarget = new WeaponItem(game, gun);
            }
            else
            {
                newtarget = new Target(game);
            }



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
            foreach (GameEntity entity in entities)
            {
                if (EntityCollisionHandler.IsInCollision(g, entity))
                    return true;
            }
            return false;
        }
    }
}
