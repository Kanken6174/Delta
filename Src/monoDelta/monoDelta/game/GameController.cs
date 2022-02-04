﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoDelta.game
{
    public class GameController : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 baseScreenSize = new Vector2(1600, 900);
        private Matrix globalTransformation;
        int backbufferWidth, backbufferHeight;
        Texture2D circle;

        private kinect.KinectManager km;

        public GameController()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 500;
            km = new kinect.KinectManager();
        }

        /// <summary>
        /// Charge les différentes ressources du jeu (fichiers)
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.Content.RootDirectory = "";
            circle = Content.Load<Texture2D>("Art/crs");
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(circle, new Rectangle(0, 0, 100, 100), Color.Red);
            spriteBatch.End();
        }
        /// <summary>   
        /// met à jour le jeu selon une vitesse de tick prédéterminée
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
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