using Game.Model;
using Game.Model.Collisions.Handlers;
using Game.Model.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monoDelta.Game.Model;
using MonoDelta.Game.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Model.Player;
using Myra;
using Myra.Graphics2D.UI;

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
        private GameModel gameModel;
        private Desktop _desktop;

        public GameController()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = false,
                PreferredBackBufferWidth = 1200,
                PreferredBackBufferHeight = 500
            };
            IsMouseVisible = true;
            km = new Kinect.KinectManager();
        }

        /// <summary>
        /// Charge les différentes ressources du jeu (fichiers)
        /// </summary>
        protected override void LoadContent()
        {
            MyraEnvironment.Game = this;
            var panel = new Panel();
            var positionedText = new Label();
            positionedText.Text = "Positioned Text";
            positionedText.Left = 50;
            positionedText.Top = 100;
            panel.Widgets.Add(positionedText);

            var paddedCenteredButton = new TextButton();
            paddedCenteredButton.Text = "Padded Centered Button";
            paddedCenteredButton.HorizontalAlignment = HorizontalAlignment.Center;
            paddedCenteredButton.VerticalAlignment = VerticalAlignment.Center;
            panel.Widgets.Add(paddedCenteredButton);

            var rightBottomText = new Label();
            rightBottomText.Text = "Right Bottom Text";
            rightBottomText.Left = -30;
            rightBottomText.Top = -20;
            rightBottomText.HorizontalAlignment = HorizontalAlignment.Right;
            rightBottomText.VerticalAlignment = VerticalAlignment.Bottom;
            panel.Widgets.Add(rightBottomText);

            var fixedSizeButton = new TextButton();
            fixedSizeButton.Text = "Fixed Size Button";
            fixedSizeButton.Width = 110;
            fixedSizeButton.Height = 80;
            panel.Widgets.Add(fixedSizeButton);
            _desktop = new Desktop();
            _desktop.Root = panel;

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
            PlayerManager.SetPlayer(new Player(this));
        }
        /// <summary>   
        /// met à jour le jeu selon une vitesse de tick prédéterminée
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            EntityManager.ProcessNextFrame(gameTime, spriteBatch, this);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            base.Draw(gameTime);
            spriteBatch.Begin();
            if (IsMouseVisible)
            {
                GraphicsDevice.Clear(Color.Black);
                _desktop.Render();
            }
            else
            {
                EntityManager.DrawNextFrame(gameTime, spriteBatch);
            }
            spriteBatch.End();
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
