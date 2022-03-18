
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
                gun = new Handgun();
            else
                gun = LevelManager.CurrentLevel.PossibleWeapons[LevelManager.CurrentLevel.StartingGunIndex];

            if (gun.Bullet == null)
                gun.ReArmDefault(game);
            Score = 0;
            Life = LevelManager.CurrentLevel.PlayerLives;
        }

        public int Munitions { get; private set; }

        public int Life { get; private set; }

        public int Score { get; private set; }

        public Gun gun { get; private set; }
        public void DecrementLife() => Life--;

        public void IncrementScore(int toAdd) => Score += toAdd;

        public void Update(GameTime time) => gun.Shoot(time);


    }
}