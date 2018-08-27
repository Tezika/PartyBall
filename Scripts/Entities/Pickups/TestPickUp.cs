using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Entities.Pickups
{
    public class TestPickUp: Pickup
    {
        public TestPickUp(Texture2D texture, Vector2 position): base(texture, position)
        {  
        }

        public override void TakeEffect()
        {
            base.TakeEffect();
            Game1.Instance.Character.Respawn();
        }
    }
}
