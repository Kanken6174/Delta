
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.Entity{
    public class ScoreItem : BonusItem {

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