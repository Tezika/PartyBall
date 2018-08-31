using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Entities
{
    public enum PlatformType
    {
        PipeSegment,
        Wall
    }

    public class Platform : GameObject
    {
        public virtual PlatformType Type { get; }

        public Platform(Texture2D texture, Vector2 position, float scale = 1.0f) : base(position, texture)
        {
            this.Scale = scale;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}