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
    /// <summary>
    /// The EntityManager will manage all the GameEntities on the playspace, ask them to move and to draw themselves whenever the corresponding methods are called.
    /// </summary>
    public static class EntityManager
    {
        private static readonly List<GameEntity> entities = new List<GameEntity>(); //the current entities on the playspace (usually targets and bonus)

        private static readonly List<Projectile> projectiles = new List<Projectile>();  //the current projectiles on the playspace (usually smallProjectiles)

        private static List<Crosshair> crosshairs = new List<Crosshair>();  //list of the current crosshairs managed by the KinectManager

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
        /// <summary>
        /// This method is called by the main game controller, to process the positions of everyn entity for the next frame
        /// </summary>
        /// <param name="gameTime">global game timer</param>
        /// <param name="spriteBatch">game sprite helper</param>
        /// <param name="game">the game itself</param>
        public static void ProcessNextFrame(GameTime gameTime, SpriteBatch spriteBatch, Microsoft.Xna.Framework.Game game)
        {
            if(gameTime.TotalGameTime.TotalMilliseconds > gametimer + 15)
                gametimer += 15;
            else
                return;

            for (int nbelem = 0; nbelem < entities.Count; nbelem++)
            {
                entities[nbelem].Move(gameTime);    //moves every target/bonus on the playspace towards the player
                if (entities[nbelem].position.Zpos < 3) //checks if an element has collided with the player (treshold is 3 game units)
                {
                    entities.RemoveAt(nbelem);
                    PlayerManager.GetPlayer().DecrementLife(); //if we have a collision we decrement the player's life and delete that element
                }
            }

            foreach(Crosshair cr in crosshairs) //we move each crosshair (not really needed since crosshair movement is handled by the kinectManager)
            {
                cr.Move(gameTime);
            }

            PlayerManager.GetPlayer().Update(gameTime); //we update the player (may cause its gun to shoot a bullet if the shooting delay is met)

            for (int nbelem = 0; nbelem < projectiles.Count && projectiles.Count > 0; nbelem++) //move each projectile
            {
                projectiles[nbelem].Move(gameTime);
                if (projectiles[nbelem].Lifetime == 0)  //remove the projectile if it has exceeded its life time
                    projectiles.RemoveAt(nbelem);
            }

            if (gameTime.TotalGameTime.TotalMilliseconds - lastSpawned > LevelManager.CurrentLevel.TargetSpawnDelay)//if the delay is met spawn a random target
            {
                AddRandomTarget(game);
                lastSpawned = gameTime.TotalGameTime.TotalMilliseconds;
            }

            for (int j = 0; j < entities.Count; j++)    //here we will check the collision for each target/bonus
            {
                for (int i = 0; i < projectiles.Count; i++) //with each projectile
                {
                    if (j < entities.Count &&  EntityCollisionHandler.HasProjectileCollidedWith(projectiles[i], entities[j]))
                    {
                        entities.RemoveAt(j);   //remove the target if one of the projectile has hit it
                        PlayerManager.GetPlayer().IncrementScore(10);
                    }
                }
            }
        }

        public static void DrawNextFrame(GameTime gameTime, SpriteBatch spriteBatch)    //calls the draw method of each GameEntity in the 3 lists
        {
            foreach (GameEntity e in entities)
                e.Draw(gameTime, spriteBatch);

            foreach (Projectile p in projectiles)
                p.Draw(gameTime, spriteBatch);

            foreach (Crosshair crosshair in crosshairs)
                crosshair.Draw(gameTime, spriteBatch);
        }

        /// <summary>
        /// Will randomly add a target on the game's playspace, can also add a bonus instead
        /// </summary>
        /// <param name="game">the Xna game</param>
        public static void AddRandomTarget(Microsoft.Xna.Framework.Game game)
        {
            CollisionnableEntity newtarget;
            double rand = randomiser.NextDouble();
            if (rand < LevelManager.CurrentLevel.BonusChance && LevelManager.CurrentLevel.PossibleWeapons.Count > 0) //1/100 chances
            {
                int randomGunIndex = randomiser.Next(0, LevelManager.CurrentLevel.PossibleWeapons.Count());
                Gun gun = LevelManager.CurrentLevel.PossibleWeapons[randomGunIndex];
                newtarget = new WeaponItem(game, gun);
            }
            else
            {
                newtarget = new Target(game);
            }

            int tries = 0;  //while the target's hitbox collides with another target, try to place it again, up to 150 tries
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

        /// <summary>
        /// This method checks if a GameEntity collieds with any of the others on the 2d plane
        /// </summary>
        /// <param name="g">GameEntity to check for collisions with the others</param>
        /// <returns></returns>
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
