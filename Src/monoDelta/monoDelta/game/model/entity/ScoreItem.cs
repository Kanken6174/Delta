using Microsoft.Xna.Framework;
using System;

namespace Game.Model.Entity
{
    /// <summary>
    /// Unused game entity which would've let the player earn 1000 points upon hitting it with a projectile
    /// </summary>
    public class ScoreItem : BonusItem
    {

        public ScoreItem(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }

        public int scoretoAdd;

    }
}