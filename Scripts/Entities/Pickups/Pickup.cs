using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Entities.Pickups
{
    public class Pickup: GameObject
    {
        public Pickup(Texture2D texture, Vector2 position): base(position, texture)
        {

        }

        public virtual void TakeEffect()
        {

        }
    }
}
