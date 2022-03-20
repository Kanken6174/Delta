
using Game.Model.Entity.Projectiles;
using Game.Model.Weapons;
using Microsoft.Xna.Framework;
using monoDelta.Game.Model.Levels;

namespace Game.Model.Player
{
    public class Player
    {

        public Player(Microsoft.Xna.Framework.Game game)
        {
            if (LevelManager.CurrentLevel.PossibleWeapons.Count <= 0)
                gun = new Handgun(new SmallProjectile(game));
            else
                gun = LevelManager.CurrentLevel.PossibleWeapons[LevelManager.CurrentLevel.StartingGunIndex];

            if (!gun.hasBullet())
                gun.ReArmDefault(game);
            Score = 0;
            Life = LevelManager.CurrentLevel.PlayerLives;
        }

        public int Life { get; private set; }

        public int Score { get; private set; }

        /// <summary>
        /// The player's current active weapon, it will be responsible for firing bullets through the crosshair's position
        /// </summary>
        public Gun gun { get; private set; }
        public void DecrementLife() => Life--;

        /// <summary>
        /// Increments the player's score
        /// </summary>
        /// <param name="toAdd"></param>
        public void IncrementScore(int toAdd) => Score += toAdd;

        /// <summary>
        /// this method is mainly used to fire the player's weapon when a certain firing delay is met
        /// </summary>
        /// <param name="time"></param>
        public void Update(GameTime time) => gun.Shoot(time);

        /// <summary>
        /// Checks if the player's score has exceeded the level's win treshold
        /// </summary>
        public bool HasWon =>  (Score > LevelManager.CurrentLevel.WinScore);

    }
}