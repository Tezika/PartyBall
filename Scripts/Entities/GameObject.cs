using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Entities 
{
    public class GameObject
    {
        public BoundingBox bounding { get; set; }

        public GameObject()
        {

        }

        public virtual void Initialize(Texture2D texture, Vector2 position)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
