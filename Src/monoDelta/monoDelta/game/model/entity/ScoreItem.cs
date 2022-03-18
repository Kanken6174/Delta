using System;

namespace Game.Model.Entity
{
    public class ScoreItem : BonusItem
    {

        public ScoreItem(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }

        public int scoretoAdd;

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}