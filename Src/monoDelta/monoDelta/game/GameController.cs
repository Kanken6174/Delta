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
using monoDelta.Game.Model.Levels;
using Game.Model.Weapons;
using Game.Model.Entity.Projectiles;

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
        Stopwatch timer;
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
            timer = new Stopwatch();
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
            timer.Start();
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
            LevelManager.loadAllLevels(this);
            LevelManager.CurrentLevel.PossibleWeapons.Add(new Handgun(null));
            LevelManager.serializeCurrentLevel();
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
                positionedText.Text = "vie " + PlayerManager.GetPlayer().Life.ToString() + " Score: " + PlayerManager.GetPlayer().Score.ToString() + " temps: " + timer.Elapsed;
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

            var level1 = new TextButton();
            level1.Text = "LEVEL 1";
            level1.Top = 400;
            level1.Left = 300;
            level1.TouchDown += (sender, args) => LevelOneHit();
            panel.Widgets.Add(level1);

            var level2 = new TextButton();
            level2.Text = "LEVEL 2";
            level2.Top = 400;
            level2.Left= 600;
            
            level2.Enabled = true;

            panel.Widgets.Add(level2);

            _desktop = new Desktop();
            _desktop.Root = panel;
        }

        public void LevelOneHit()
        {
            LevelManager.CurrentLevel = new Level();
            timer.Restart();
            IsMouseVisible = false;
            GameTime gametime = new GameTime();
            PlayerManager.SetPlayer(new Player(this));
            this.LoadContent();
        }

        private void drawGameOverUI()
        {
            MyraEnvironment.Game = this;
            var panel = new Panel();

            var gm_btn = new TextButton();
            gm_btn.VerticalAlignment= VerticalAlignment.Center;
            gm_btn.HorizontalAlignment = HorizontalAlignment.Center;
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
