using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.Render
{
    //Cite this from the http://csharpindepth.com/Articles/General/Singleton.aspx, perhaps need to review it one day.
    //This singlton serves for handling the rendering stuff.
    public sealed class RenderManager
    {
        private static readonly RenderManager instance = new RenderManager();

        public GraphicsDeviceManager Graphics { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public int ScreenHeight
        {
            get
            {
                return this.Graphics.PreferredBackBufferHeight;
            }
        }

        public int ScreenWidth
        {
            get
            {
                return this.Graphics.PreferredBackBufferWidth;
            }
        }

        private Texture2D _Pixel;

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
            //Setup window size
            this.Graphics.PreferredBackBufferWidth = 320;
            this.Graphics.PreferredBackBufferHeight = 640;
            this.Graphics.ApplyChanges();

            this.SpriteBatch = new SpriteBatch(gameInstance.GraphicsDevice);

            // Somewhere in your LoadContent() method:
            _Pixel = new Texture2D(gameInstance.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            _Pixel.SetData(new[] { Color.White }); // so that we can draw whatever color we want on top of it
        }

        public void DrawGameObject(GameObject gameObject, float layerDepth = 1.0f)
        {
            if (!gameObject.Visible)
            {
                return;
            }
            this.SpriteBatch.Begin(transformMatrix: Game1.Instance.Camera.Transform);
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

            //Draw the boundingbox outline - debug function
            this.DrawBorder(gameObject.BoundingBox, 1, Color.Purple);
            this.SpriteBatch.End();
        }

        public void DrawString(String str, SpriteFont font, Vector2 position)
        {
            this.SpriteBatch.Begin();
            this.SpriteBatch.DrawString(font, str, position, Color.Black);
            this.SpriteBatch.End();
        }

        private void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            // Draw top line
            this.SpriteBatch.Draw(_Pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            this.SpriteBatch.Draw(_Pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            this.SpriteBatch.Draw(_Pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            this.SpriteBatch.Draw(_Pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);
        }
    }
}
