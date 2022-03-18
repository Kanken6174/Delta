using Game.Model;
using Game.Model.Entity;
using Game.Model.Player;
using Game.Model.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monoDelta.Game.Model;
using monoDelta.Game.Model.Levels;
using MonoDelta.Game.Model.Entity;
using Myra;
using Myra.Graphics2D.UI;
using System;
using System.Diagnostics;

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
        private Desktop _desktop;
        Stopwatch timer;
        private bool justExittedGame = false, firstGame = true, gameOver = false, hasWon = false;


        public GameController()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = false,
                PreferredBackBufferWidth = 1200,
                PreferredBackBufferHeight = 500
            };
            timer = new Stopwatch();
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
            timer.Start();
            Crosshair crosshair = new Crosshair(this);
            EntityManager.SetCrosshair(crosshair);
            km.Init();
            for (int i = 0; i < LevelManager.CurrentLevel.StartTargetAmount; i++)
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

            if (PlayerManager.GetPlayer().HasWon)
            {
                ResetGame();
                timer.Stop();
                justExittedGame = IsMouseVisible = hasWon = true;
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            if (PlayerManager.GetPlayer().Life <= 0)
            {
                ResetGame();
                justExittedGame = gameOver = IsMouseVisible = true;
                drawGameOver();

            }
            base.Draw(gameTime);

            if (IsMouseVisible  && hasWon)
            {
                DrawWon();
            }

            else if (IsMouseVisible && gameOver)
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
                var positionedText = new Label
                {
                    Text = "vie " + PlayerManager.GetPlayer().Life.ToString() + " Score: " + PlayerManager.GetPlayer().Score.ToString() + " temps: " + timer.Elapsed,
                    Left = 400,
                    Top = 465
                };
                Myra.Graphics2D.Brushes.SolidBrush black = new Myra.Graphics2D.Brushes.SolidBrush(Color.Black);
                positionedText.Background = black;
                panel.Widgets.Add(positionedText);
                _desktop = new Desktop
                {
                    Root = panel
                };
                _desktop.Render();
            }
        }

        private void ResetGame()
        {
            PlayerManager.SetPlayer(new Player(this));
            EntityManager.ClearAll();
            km.Stop();
            km.Init();
        }

        private void drawMenu()
        {
            if (justExittedGame)
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
                DrawGameOverUI();
                justExittedGame = false;
            }
            _desktop.Render();
        }

        private void drawMenuUI()
        {
            MyraEnvironment.Game = this;
            var panel = new Panel();

            var titre = new Label
            {
                Text = "Target Wave",
                HorizontalAlignment = HorizontalAlignment.Center,
                Top = 50,
                TextColor = Color.Black
            };
            panel.Widgets.Add(titre);

            var level1 = new TextButton
            {
                Text = "LEVEL 1",
                Top = 400,
                Left = 300
            };
            level1.TouchDown += (sender, args) => LevelOneHit();
            panel.Widgets.Add(level1);

            var level2 = new TextButton
            {
                Text = "LEVEL 2",
                Top = 400,
                Left = 600,

                Enabled = true
            };

            panel.Widgets.Add(level2);

            _desktop = new Desktop();
            _desktop.Root= panel;

        }

        public void DrawWon()
        {
            if (justExittedGame)
            {
                DrawWonUI();
                justExittedGame = false;
            }
            _desktop.Render();
        }

        private void DrawWonUI()
        {
            MyraEnvironment.Game = this;
            var panel = new Panel();

            var textFinal = new Label();
            textFinal.Text = "Vous avez gagné le niveau ! ";
            textFinal.HorizontalAlignment = HorizontalAlignment.Center;
            textFinal.Top = 50;
            textFinal.TextColor = Color.Black;
            panel.Widgets.Add(textFinal);

            var textScore = new Label();
            textScore.TextColor = Color.Black;
            textScore.HorizontalAlignment= HorizontalAlignment.Center;
            textScore.Top = 100;
            textScore.Text = "Il vous reste : " + PlayerManager.GetPlayer().Life.ToString() + " vies, votre temps : " + timer.Elapsed;

            var btn_exit = new TextButton();
            btn_exit.Text = "Appuie methode back menu ";
            btn_exit.VerticalAlignment = VerticalAlignment.Center;
            btn_exit.HorizontalAlignment = HorizontalAlignment.Center;

            btn_exit.TouchDown += (sender, args) => BackMenu();
            btn_exit.Enabled = true;

            panel.Widgets.Add(btn_exit);
            panel.Widgets.Add(textScore);

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

        private void DrawGameOverUI()
        {
            MyraEnvironment.Game = this;
            var panel = new Panel();

            var gm_btn = new TextButton
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = "Retour au menu"
            };
            gm_btn.TouchDown += (sender, args) => BackMenu();
            gm_btn.Enabled = true;

            panel.Widgets.Add(gm_btn);


            _desktop = new Desktop
            {
                Root = panel
            };
        }

        public void BackMenu()
        {
            GameTime gt = new GameTime();
            PlayerManager.SetPlayer(new Player(this));
            IsMouseVisible = true;
            justExittedGame = true;
            hasWon = false;
            gameOver = false;
            Draw(gt);
        }

        
    }
}
