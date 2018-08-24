using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Entities
{
    public class RegularPlatform: Platform
    {
        public RegularPlatform(Texture2D texture, Vector2 position) : base(texture, position)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
