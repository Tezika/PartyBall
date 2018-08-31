using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;
using System;

namespace PartyBall.Scripts.Render
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public Vector2 Centre { get; private set; }

        public Camera()
        {
            this.Transform = new Matrix();
        }
 public void Update(GameTime gameTime, Character character)
        {
            this.Centre = new Vector2(0, character.Position.Y + character.Height / 2 - RenderManager.Instance.ScreenHeight * 0.8f);
            this.Transform = Matrix.CreateScale(new Vector3(1, 1, 0)) 
                            * Matrix.CreateTranslation(new Vector3(-this.Centre.X, -this.Centre.Y, 0));

        }
    }
}
