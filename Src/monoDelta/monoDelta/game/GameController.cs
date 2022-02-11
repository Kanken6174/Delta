using Game.Model.Collisions.Handlers;
using Game.Model.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDelta.Game.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDelta.Game
{
    public class GameController : Microsoft.Xna.Framework.Game
    {
#pragma warning disable IDE0052 // Supprimer les membres privés non lus
        readonly GraphicsDeviceManager graphics;
#pragma warning restore IDE0052 // Supprimer les membres privés non lus
        SpriteBatch spriteBatch;
        Vector2 baseScreenSize = new Vector2(1600, 900);
        int backbufferWidth, backbufferHeight;
#pragma warning disable IDE0052 // Supprimer les membres privés non lus
        private Matrix globalTransformation;
#pragma warning restore IDE0052 // Supprimer les membres privés non lus
        private readonly Kinect.KinectManager km;

        public GameController()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = false,
                PreferredBackBufferWidth = 1200,
                PreferredBackBufferHeight = 500
            };
            km = new Kinect.KinectManager();
        }

        /// <summary>
        /// Charge les différentes ressources du jeu (fichiers)
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.Content.RootDirectory = "";

            GraphicsDevice.Clear(Color.White);
            Crosshair crosshair = new Crosshair(this);
            EntityManager.SetCrosshair(crosshair);
            km.Init();
            for (int i = 0; i < 75; i++)
            {
                EntityManager.AddRandomTarget(this);
            }
        }
        /// <summary>   
        /// met à jour le jeu selon une vitesse de tick prédéterminée
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            EntityManager.DrawAll(gameTime, spriteBatch);
            spriteBatch.End();
            base.Update(gameTime);
        }

        public void ScalePresentationArea()
        {
            //Work out how much we need to scale our graphics to fill the screen
            backbufferWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            backbufferHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;
            float horScaling = backbufferWidth / baseScreenSize.X;
            float verScaling = backbufferHeight / baseScreenSize.Y;
            Vector3 screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            globalTransformation = Matrix.CreateScale(screenScalingFactor);
            
        }
    }
}
