using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PartyBall.Scripts.Level;
using PartyBall.Scripts.Render;
using PartyBall.Scripts.Singleton;

namespace PartyBall
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static Game1 Instance = null;

        public Level CurLevel { get; private set; }

        public Game1()
        {
            RenderManager.Instance.Graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.CurLevel = new Level();
            Game1.Instance = this;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            this.CurLevel.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            RenderManager.Instance.Setup(this);
            Debugger.Instance.Setup(this);

            // TODO: use this.Content to load your game content here
            // Load the player resources
            this.CurLevel.LoadContent(this);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            this.CurLevel.UnloadContent();
        }

        /// <summary>    
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            this.CurLevel.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            this.CurLevel.Draw(gameTime);
            Debugger.Instance.DrawDebugInfo();

            //Draw title!!!
            RenderManager.Instance.DrawString("PartyBaller", Debugger.Instance.Font, new Vector2((float)0.4 * RenderManager.Instance.Graphics.GraphicsDevice.Viewport.Width,
                                                                                                  (float)0.01 * RenderManager.Instance.Graphics.GraphicsDevice.Viewport.Height));
            base.Draw(gameTime);
        }
    }
}
