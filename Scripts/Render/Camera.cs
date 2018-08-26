using System;
using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.Render
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public Camera()
        {
            this.Transform = new Matrix();
        }

        public void FollowCharacter(Character character)
        {
            var offset = Matrix.CreateTranslation((int)(RenderManager.Instance.ScreenWidth * 0.6), (int)(RenderManager.Instance.ScreenHeight * 0.8), 0);
            var position = Matrix.CreateTranslation(-character.Position.X - character.Width / 2, -character.Position.Y - character.Height / 2, 0);
            this.Transform = offset * position;
        }
    }
}
