using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PartyBall.Scripts.Singleton;

namespace PartyBall.Scripts.Entities
{
    public class RegularPlatform: Platform
    {
        public override PlatformType type
        {
            get
            {
                return PlatformType.Regular;
            }
        }

        public RegularPlatform(Texture2D texture, Vector2 position) : base(texture, position)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void CheckCharacterCollision(Rectangle characterBB)
        {
            base.CheckCharacterCollision(characterBB);
            if (this.BoundingBox.Intersects(characterBB))
            {
                Debugger.Instance.Log("The character enter the bounding box");
            }
            else
            {
                Debugger.Instance.Log("The character is not in the bounding box");
            }
           
        }

    }
}
