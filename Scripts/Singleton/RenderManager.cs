using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.Singleton
{
    //Cite this from the http://csharpindepth.com/Articles/General/Singleton.aspx, perhaps need to review it one day.
    //This singlton serves for handling the rendering stuff.
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

        public void DrawGameObject(GameObject gameObject, float layerDepth = 1.0f)
        {
            if (!gameObject.Visible)
            {
                return;
            }
            this.SpriteBatch.Begin();
            this.SpriteBatch.Draw(texture: gameObject.Texture,
                                  position: gameObject.Position,
                                  sourceRectangle: null,
                                  color: Color.White,
                                  rotation: 0.0f,
                                  scale: gameObject.Scale,
                                  origin: gameObject.Origin,
                                  effects: SpriteEffects.None,
                                  layerDepth: layerDepth
                                  );
            this.SpriteBatch.End();
        }

        public void DrawString(String str, SpriteFont font, Vector2 position)
        {
            this.SpriteBatch.Begin();
            this.SpriteBatch.DrawString(font, str, position, Color.Black);
            this.SpriteBatch.End();
        }
    }
}
