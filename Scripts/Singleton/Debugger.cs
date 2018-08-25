using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Singleton
{
    public sealed class Debugger
    {
        private static readonly Debugger instance = new Debugger();

        public SpriteFont Font { get; private set; }

        public string DebugInfo { get; private set; }

        static Debugger()
        {

        }

        private Debugger()
        {

        }

        public static Debugger Instance
        {
            get
            {
                return instance;
            }
        }

        public void Setup(Game gameInstance)
        {
            this.Font = gameInstance.Content.Load<SpriteFont>("spritefont//debug");
        }

        public void DrawDebugInfo()
        {
            RenderManager.Instance.DrawString(this.DebugInfo, this.Font, new Vector2(460, 10));
        }

        public void Log(string str)
        {
            this.DebugInfo = "PR: " + str;
        }
    }
}