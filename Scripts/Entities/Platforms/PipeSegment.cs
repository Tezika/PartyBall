using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Entities
{
    public enum SegmentType
    {
        Left,
        Middle,
        Right,
        None
    }

    public class PipeSegment: Platform
    {
        public override PlatformType Type
        {
            get
            {
                return PlatformType.PipeSegment;
            }
        }

        public SegmentType SegmentType { get; internal set; }

        public PipeSegment(Texture2D texture, Vector2 position, float scale = 1.0f) : base(texture, position, scale)
        {
            this.SegmentType = SegmentType.None;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
