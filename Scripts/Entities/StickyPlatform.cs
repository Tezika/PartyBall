using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Entities
{
    public class StickyPlatform : Platform
    {
        public StickyPlatform(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void CheckCharacterCollision(Rectangle characterBB)
        {
            base.CheckCharacterCollision(characterBB);
        }
    }
}
