using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Entities
{
    public enum WallSide
    {
        Left,
        Right
    }

    public class Wall : Platform
    {

        public WallSide Side { get; set; }

        public override PlatformType Type
        {
            get
            {
                return PlatformType.Wall;
            }
        }

        public Wall(Texture2D texture, Vector2 position) : base(texture, position)
        {
            this.Side = WallSide.Left;
        }


    }
}
