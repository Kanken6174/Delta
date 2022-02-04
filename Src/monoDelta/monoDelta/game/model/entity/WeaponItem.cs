
using game.model.weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.model.entity{
    public class WeaponItem : BonusItem {

        public WeaponItem(Game game) : base(game)
        {
        }

        public Gun newGun;

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }
    }
}