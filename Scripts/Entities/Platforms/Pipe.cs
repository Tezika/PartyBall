using Microsoft.Xna.Framework;

namespace PartyBall.Scripts.Entities.Platforms
{
    public class Pipe: GameObject
    {
        public PipeSegment LeftSegment { get; private set; }

        public PipeSegment MiddleSegment { get; private set; }

        public PipeSegment RightSegment { get; private set; }

        public Pipe(Vector2 position): base(position)
        {
       
            this.LeftSegment = new PipeSegment(Graphics.PipeSegment_Left, Vector2.Zero, 0.15f);
            this.MiddleSegment = new PipeSegment(Graphics.PipeSegment_Middle, Vector2.Zero, 0.15f);
            this.RightSegment = new PipeSegment(Graphics.PipeSegement_Right, Vector2.Zero, 0.15f);

            this.MiddleSegment.Position = position;
            this.LeftSegment.Position = new Vector2(position.X - (this.MiddleSegment.Width * this.MiddleSegment.Scale), position.Y);
            this.RightSegment.Position = new Vector2(position.X  + (this.MiddleSegment.Width * this.MiddleSegment.Scale), position.Y);

            Game1.Instance.CurLevel.Platforms.Add(this.LeftSegment);
            Game1.Instance.CurLevel.Platforms.Add(this.MiddleSegment);
            Game1.Instance.CurLevel.Platforms.Add(this.RightSegment);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}