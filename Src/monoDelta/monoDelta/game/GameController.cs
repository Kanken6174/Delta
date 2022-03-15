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
        private bool justExittedGame = false, firstGame = true, gameOver = false;

        public GameController()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = false,
                PreferredBackBufferWidth = 1200,
                PreferredBackBufferHeight = 500
            };
            IsMouseVisible = true;
            gameOver = false;
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
            PlayerManager.SetPlayer(new Player(this));
            if (firstGame)
            {
                firstGame = false;
                drawMenuUI();
            }
        }
        /// <summary>   
        /// met à jour le jeu selon une vitesse de tick prédéterminée
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!IsMouseVisible)
            {
                EntityManager.ProcessNextFrame(gameTime, spriteBatch, this);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            if (PlayerManager.GetPlayer().Life <= 0)
            {
                resetGame();
                justExittedGame = gameOver = IsMouseVisible = true;
                drawGameOver();

            }
            base.Draw(gameTime);

            if(IsMouseVisible && gameOver)
            {
                drawGameOver();
            }

            
            else if (IsMouseVisible && !gameOver)
            {
                drawMenu();
            }
            else
            {
                spriteBatch.Begin();
                EntityManager.DrawNextFrame(gameTime, spriteBatch);
                spriteBatch.End();
                var panel = new Panel();
                var positionedText = new Label();
                positionedText.Text = "vie " + PlayerManager.GetPlayer().Life.ToString() + " Score: " + PlayerManager.GetPlayer().Score.ToString() + " temps: " + gameTime.TotalGameTime.TotalSeconds.ToString();
                positionedText.Left = 400;
                positionedText.Top = 465;
                Myra.Graphics2D.Brushes.SolidBrush black = new Myra.Graphics2D.Brushes.SolidBrush(Color.Black);
                positionedText.Background = black;
                panel.Widgets.Add(positionedText);
                _desktop = new Desktop();
                _desktop.Root = panel;
                _desktop.Render();
            }
        }

        private void resetGame()
        {
            PlayerManager.SetPlayer(new Player(this));
            EntityManager.ClearAll();
            km.Stop();
            km.Init();
        }

        private void drawMenu()
        {
            if (justExittedGame )
            {
                drawMenuUI();
                justExittedGame = false;
            }
            _desktop.Render();
        }

        private void drawGameOver()
        {
            if (justExittedGame)
            {
                drawGameOverUI();
                justExittedGame = false;
            }
            _desktop.Render();
        }

        private void drawMenuUI()
        {
            MyraEnvironment.Game = this;
            var panel = new Panel();

            var titre = new Label();
            titre.Text = "Target Wave";
            titre.HorizontalAlignment = HorizontalAlignment.Center;
            titre.Top = 50;
            titre.TextColor = Color.Black;
            panel.Widgets.Add(titre);


            var paddedCenteredButton = new TextButton();
            paddedCenteredButton.Text = "Click to play";
            paddedCenteredButton.HorizontalAlignment = HorizontalAlignment.Center;
            paddedCenteredButton.VerticalAlignment = VerticalAlignment.Center;
            paddedCenteredButton.TouchDown += (sender, args) => PaddedCenteredButton_TouchUp();
            paddedCenteredButton.Enabled = true;

            panel.Widgets.Add(paddedCenteredButton);

            _desktop = new Desktop();
            _desktop.Root = panel;
        }

        public void PaddedCenteredButton_TouchUp()
        {
            IsMouseVisible = false;
            PlayerManager.SetPlayer(new Player(this));
            this.LoadContent();
        }

        private void drawGameOverUI()
        {
            MyraEnvironment.Game = this;
            var panel = new Panel();

            var gm_btn = new TextButton();
            gm_btn.Text = "Retour au menu";
            gm_btn.TouchDown += (sender, args) => backMenu();
            gm_btn.Enabled = true;

            panel.Widgets.Add(gm_btn);


            _desktop = new Desktop();
            _desktop.Root = panel;
        }

        public void backMenu()
        {
            GameTime gt = new GameTime();
            PlayerManager.SetPlayer(new Player(this));
            IsMouseVisible = true;
            justExittedGame = true;
            gameOver = false;
            Draw(gt);
        }
    }
}
