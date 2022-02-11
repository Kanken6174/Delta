
using Game.Model.weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Model.entity{
    public class WeaponItem : BonusItem {

        public WeaponItem(Microsoft.Xna.Framework.Game game) : base(game)
        {
        }

        public Gun newGun;

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }
    }
}