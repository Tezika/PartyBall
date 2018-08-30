using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Entities
{
    public class Pipe: Platform
    {
        public override PlatformType Type
        {
            get
            {
                return PlatformType.Pipe;
            }
        }

        public Pipe(Texture2D texture, Vector2 position, float scale = 1.0f) : base(texture, position, scale)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
