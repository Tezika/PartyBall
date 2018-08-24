using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.Singleton
{
    //cite from the http://csharpindepth.com/Articles/General/Singleton.aspx, perhaps need to review it one day.
    public sealed class RenderManager
    {
        private static readonly RenderManager instance = new RenderManager();

        public GraphicsDeviceManager Graphics;

        public SpriteBatch SpriteBatch;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static RenderManager()
        {

        }
        private RenderManager()
        {
        }

        public static RenderManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void Setup(Game gameInstance)
        {
            this.SpriteBatch = new SpriteBatch(gameInstance.GraphicsDevice);
        }

        public void DrawGameObject(GameObject gameObject)
        {
            if (!gameObject.Visible)
            {
                return;
            }
            this.SpriteBatch.Begin();
            this.SpriteBatch.Draw(gameObject.Texture, gameObject.Position, Color.White);
            this.SpriteBatch.End();
        }
    }
}
