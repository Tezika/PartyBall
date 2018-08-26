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
            this.DebugInfo = "";
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
            RenderManager.Instance.DrawString(this.DebugInfo,
                                              this.Font,
                                              new Vector2(0, (float)RenderManager.Instance.Graphics.GraphicsDevice.Viewport.Height - 20.0f));
        }

        public void Log(string str)
        {
            this.DebugInfo = "Debug:" + str;
            RenderManager.Instance.DrawString(this.DebugInfo,
                                              this.Font,
                                              new Vector2(0, (float)RenderManager.Instance.Graphics.GraphicsDevice.Viewport.Height - 20.0f));
        }
    }
}