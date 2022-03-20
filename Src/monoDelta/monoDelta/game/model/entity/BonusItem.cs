
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monoDelta.Game.Model.Entity;

namespace Game.Model.Entity
{
    /// <summary>
    ///     BonusItems are  a subclass of the CollisionnableEntity which can be shot at by the player in the same way as a target but with a special effect to it.
    /// </summary>
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