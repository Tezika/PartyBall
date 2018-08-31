using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PartyBall
{
    public static class Graphics
    {
        public static Texture2D StartMenu;

        public static Texture2D GameOverScreen;

        public static SpriteFont Font;

        public static Texture2D Ball;

        public static Texture2D Wall_Left;

        public static Texture2D Wall_Right;

        public static Texture2D Pipe;

        public static Texture2D ShadesPickup;

        public static Texture2D BgScreen;

        public static void load(ContentManager content)
        {
            //Modify by Tezika
            StartMenu = content.Load<Texture2D>("texture\\StartScreen");
            GameOverScreen = content.Load<Texture2D>("Graphics\\endMenu");
            Font = content.Load<SpriteFont>("Graphics\\gameFont");
            Ball = content.Load<Texture2D>("texture\\characterSpriteSheet");
            Wall_Left = content.Load<Texture2D>("texture\\wall_left");
            Wall_Right = content.Load<Texture2D>("texture\\wall_right");
            Pipe = content.Load<Texture2D>("texture\\pipesegment");
            ShadesPickup = content.Load<Texture2D>("texture\\shadesPickup");
            BgScreen = content.Load<Texture2D>("texture\\bgscreen");
        }
    }
}
