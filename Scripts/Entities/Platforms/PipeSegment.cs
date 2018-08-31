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

        public int SegmentHeight
        {
            get
            {
                if (this.SegmentType == SegmentType.Middle || this.SegmentType == SegmentType.None)
                {
                    return 0;
                }
                else
                {
                    return (this.BoundingBox.Right - this.BoundingBox.Left);
                }
            }
        }


        public PipeSegment(Texture2D texture, Vector2 position, float scale = 1.0f, SegmentType type = SegmentType.None) : base(texture, position, scale)
        {
            this.SegmentType = type;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
