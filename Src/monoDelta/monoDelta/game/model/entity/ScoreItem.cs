
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.entity{
    public class ScoreItem : BonusItem {

        public ScoreItem(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }

        public int scoretoAdd;
    }
}