using Microsoft.Xna.Framework;

namespace PartyBall.Scripts.Entities.Platforms
{
    public class Pipe: GameObject
    {
        public PipeSegment LeftSegment { get; private set; }

        public PipeSegment MiddleSegment { get; private set; }

        public PipeSegment RightSegment { get; private set; }

        public Pipe(Vector2 position, bool left = true, bool middle = true, bool right = true): base(position)
        {
       
            if (left)
            {
                this.LeftSegment = new PipeSegment(Graphics.PipeSegment_Left, Vector2.Zero, 0.12f, SegmentType.Left);
                this.LeftSegment.Position = new Vector2(position.X - (this.LeftSegment.Width * this.LeftSegment.Scale), position.Y);
                Game1.Instance.CurLevel.Platforms.Add(this.LeftSegment);
            }

            if (middle)
            {
                this.MiddleSegment = new PipeSegment(Graphics.PipeSegment_Middle, Vector2.Zero, 0.12f, SegmentType.Middle);
                this.MiddleSegment.Position = position;
                Game1.Instance.CurLevel.Platforms.Add(this.MiddleSegment);
            }

            if (right)
            {
                this.RightSegment = new PipeSegment(Graphics.PipeSegement_Right, Vector2.Zero, 0.12f, SegmentType.Right);
                this.RightSegment.Position = new Vector2(position.X + (this.RightSegment.Width * this.RightSegment.Scale), position.Y);
                Game1.Instance.CurLevel.Platforms.Add(this.RightSegment);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}