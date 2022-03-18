
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monoDelta.Game.Model.Entity;

namespace Game.Model.Entity
{
    public abstract class BonusItem : CollisionnableEntity
    {
        public BonusItem(Microsoft.Xna.Framework.Game game) : base(game)
        {

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }
    }
}