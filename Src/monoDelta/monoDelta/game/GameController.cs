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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MonoDelta.Game
{
    public class GameController : Microsoft.Xna.Framework.Game
    {
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 baseScreenSize = new Vector2(1600, 900);
#pragma warning disable CS0169 // Le champ 'GameController.backbufferHeight' n'est jamais utilisé
#pragma warning disable CS0169 // Le champ 'GameController.backbufferWidth' n'est jamais utilisé
        int backbufferWidth, backbufferHeight;
#pragma warning restore CS0169 // Le champ 'GameController.backbufferWidth' n'est jamais utilisé
#pragma warning restore CS0169 // Le champ 'GameController.backbufferHeight' n'est jamais utilisé
#pragma warning disable CS0169 // Le champ 'GameController.globalTransformation' n'est jamais utilisé
        private Matrix globalTransformation;
#pragma warning restore CS0169 // Le champ 'GameController.globalTransformation' n'est jamais utilisé
        private readonly Kinect.KinectManager km;
        private Desktop _desktop;
        Stopwatch timer;
        private bool justExittedGame = false, firstGame = true, gameOver = false, hasWon = false;
        private List<Level> levelCreer = new List<Level>();
        private List<Level> tmp= new List<Level>();

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

            timer = new Stopwatch();
            EntityManager.Init(this);
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
            km.Init();
            for (int i = 0; i < LevelManager.CurrentLevel.StartTargetAmount; i++)
            {
                EntityManager.AddRandomTarget(this);
            }
            PlayerManager.SetPlayer(new Player(this));
            if (firstGame)
            {
                drawMenuUI();
                firstGame = false;
                
            }
            LevelManager.loadAllLevels(this);
            LevelManager.CurrentLevel.PossibleWeapons.Add(new Handgun(null));
            LevelManager.CurrentLevel.PossibleWeapons.Add(new Minigun(null));
            LevelManager.CurrentLevel.PossibleWeapons.Add(new Carabine(null));
            LevelManager.CurrentLevel.PossibleWeapons.Add(new Shotgun(null));
            LevelManager.CurrentLevel.PossibleWeapons.Add(new Carabine(null));
            
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

        /// <summary>
        /// Va appeler les différents methodes Draw pour dessiner la bonne interface
        /// </summary>
        /// <param name="gameTime"></param>
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

            if (IsMouseVisible  && hasWon) // Cas ou le joueur a gagné 
            {
                DrawWon();
            }

            else if (IsMouseVisible && gameOver) // Cas ou le joueur a perdu 
            {
                drawGameOver();
            }


            else if (IsMouseVisible && !gameOver) // Cas ou le joueur n'est pas en partie 
            {
                drawMenu();
            }
            else // Draw la partie 
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
                var levelName = new Label
                {
                    Text = LevelManager.CurrentLevel.LevelName,
                    Left = 10,
                    Top = 465,
                    TextColor = Color.Black
            };
                Myra.Graphics2D.Brushes.SolidBrush black = new Myra.Graphics2D.Brushes.SolidBrush(Color.Black);
                positionedText.Background = black;
                panel.Widgets.Add(levelName);
                panel.Widgets.Add(positionedText);
                _desktop = new Desktop
                {
                    Root = panel
                };
                _desktop.Render();
            }
        }

        /// <summary>
        /// Réinitialise les stats, les entités et le relaunch le kinect
        /// </summary>
        private void ResetGame()
        {
            PlayerManager.SetPlayer(new Player(this));
            EntityManager.ClearAll();
            km.Stop();
            km.Init();
        }
        /// <summary>
        /// Appelle la méthode qui va draw l'interface Menu
        /// </summary>
        private void drawMenu()
        {
            if (justExittedGame)
            {
                drawMenuUI();
                justExittedGame = false;
            }
            _desktop.Render();
        }
        /// <summary>
        /// Appelle la méthode qui va draw l'interface du GameOver
        /// </summary>
        private void drawGameOver()
        {
            if (justExittedGame)
            {
                DrawGameOverUI();
                justExittedGame = false;
            }
            _desktop.Render();
        }
        /// <summary>
        /// Draw l'interface du Menu
        /// </summary>
        private void drawMenuUI()
        {
            MyraEnvironment.Game = this;
            int position = 60;
            int x = 0;
            LevelManager.loadAllLevels(this);
            int test = LevelManager.getAllLevels().Count();
            var panel = new Panel();

            var titre = new Label
            {
                Text = "Target Wave",
                HorizontalAlignment = HorizontalAlignment.Center,
                Top = 50,
                TextColor = Color.Black
            };
            panel.Widgets.Add(titre);

            var scroll = new ScrollViewer();
            scroll.HorizontalAlignment = HorizontalAlignment.Center;
            scroll.Top = 60;
            panel.Widgets.Add(scroll);
            if (levelCreer.Count == 0)//Cas de la première partie 
            {
                foreach (var level in LevelManager.getAllLevels())
                {
                    var levelButtonbis = new TextButton();
                    levelButtonbis.Text = level.LevelName;
                    levelButtonbis.Top = 400;
                    levelButtonbis.Left = position;
                    position += 200;
                    levelButtonbis.TouchDown += (sender, args) => ClickLevel(levelButtonbis.Text);
                    panel.Widgets.Add(levelButtonbis);
                    levelCreer.Add(level);
                }
            }
            else // Cas des parties suivantes 
            {
                foreach (var level in levelCreer)
                {
                    var levelButton = new TextButton();
                    levelButton.Text = levelCreer[x].LevelName;
                    levelButton.Top = 400;
                    levelButton.Left = position;
                    position += 200;
                    levelButton.TouchDown += (sender, args) => ClickLevel(levelButton.Text);
                    panel.Widgets.Add(levelButton);
                    x++;
                }
            }
            _desktop = new Desktop();
            _desktop.Root= panel;

        }
        /// <summary>
        /// Méthode quand on appuie sur un bouton "Level" qui va appeler la méthode LoadContent
        /// </summary>
        /// <param name="levelName"></param>
        public void ClickLevel(String levelName)
        {
            foreach(var level in LevelManager.getAllLevels())
            {
                if(levelName == level.LevelName)
                {
                    LevelManager.CurrentLevel = level;
                }
            }
            timer.Restart();
            IsMouseVisible = false;
            GameTime gametime = new GameTime();
            PlayerManager.SetPlayer(new Player(this));
            this.LoadContent();
        }
        /// <summary>
        /// Appelle la méthode qui dessine l'interface d'une partie gagnée
        /// </summary>
        public void DrawWon()
        {
            if (justExittedGame)
            {
                DrawWonUI();
                justExittedGame = false;
            }
            _desktop.Render();
        }
        /// <summary>
        /// Méthode qui dessine l'interface d'une partie gagnée
        /// </summary>
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
        /// <summary>
        /// Dessine l'interface du gameOver 
        /// </summary>
        private void DrawGameOverUI()
        {
            MyraEnvironment.Game = this;
            var panel = new Panel();

            var title = new Label();
            title.Text = "Vous avez perdu, votre temps : " + timer.Elapsed.ToString();
            title.HorizontalAlignment = HorizontalAlignment.Center;
            title.Top = 100;
            title.TextColor = Color.Black;
            panel.Widgets.Add(title);

            var gm_btn = new TextButton
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Text = "Retour au menu"
            };
            gm_btn.TouchDown += (sender, args) => BackMenu();
            gm_btn.Enabled = true;

            panel.Widgets.Add(gm_btn);


            _desktop = new Desktop{Root = panel};
        }
        /// <summary>
        /// Méthode appelée quand on clique sur le bouton sur l'interface gameOver ou partie Gagnée 
        /// appelle la méthode LoadContent
        /// </summary>
        public void BackMenu()
        {
            GameTime gt = new GameTime();
            PlayerManager.SetPlayer(new Player(this));
            IsMouseVisible = justExittedGame = true;
            hasWon = gameOver = false;
            this.LoadContent();
        }

        
    }
}
