using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        SpriteBatch spriteBatch;
        enum GameStates { Start, Playing }
        enum MenuOptions { Start = 30, Restart = 500, Quit = 190 }
        GameStates GameState;
        MenuOptions menuCursor;
        Rectangle rectBackground;

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
            GameState = GameStates.Start;
            menuCursor = MenuOptions.Start;

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

            spriteBatch = new SpriteBatch(GraphicsDevice);

            Graphics.load(Content);
            Sound.load(Content);
            rectBackground = new Rectangle(0, 0, 320, 640);

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

            Input.GetInputState();
            switch (GameState)
            {
                case GameStates.Start:
                    UpdateStartMenu();
                    break;
                case GameStates.Playing:
                    UpdateGamePlay(gameTime);
                    break;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            this.CurLevel.Update(gameTime);
            base.Update(gameTime);
        }


        private void UpdateStartMenu()
        {
            if (MediaPlayer.State != MediaState.Playing)
                MediaPlayer.Play(Sound.MenuMusic);

            if (Input.Start())
            {
                if (menuCursor == MenuOptions.Quit)
                    Exit();

                GameState = GameStates.Playing;
                MediaPlayer.Stop();
            }

            if (Input.Right()) menuCursor = MenuOptions.Quit;
            if (Input.Left()) menuCursor = MenuOptions.Start;
        }

        private void UpdateGameOverScreen()
        {
            if (Input.Start())
            {
                if (menuCursor == MenuOptions.Quit)
                    Exit();
                GameState = GameStates.Playing;
            }

            if (Input.Down()) menuCursor = MenuOptions.Quit;
            if (Input.Up()) menuCursor = MenuOptions.Restart;
        }

        private void UpdateGamePlay(GameTime gameTime)
        {
            if (MediaPlayer.State != MediaState.Playing)
                MediaPlayer.Play(Sound.GameMusic);
            this.CurLevel.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            switch (GameState)
            {
                case GameStates.Start:
                    DrawStartMenu();
                    break;
                case GameStates.Playing:
                    DrawGamePlay(gameTime);
                    break;
            }
            spriteBatch.End();
            Debugger.Instance.DrawDebugInfo();
            base.Draw(gameTime);
        }
        private void DrawStartMenu()
        {
            spriteBatch.Draw(Graphics.StartMenu, rectBackground, Color.White);

            spriteBatch.DrawString(Graphics.Font, ">", new Vector2((int)menuCursor, 500), Color.White);
            spriteBatch.DrawString(Graphics.Font, "Start", new Vector2(50, 500), Color.White);
            spriteBatch.DrawString(Graphics.Font, "Quit", new Vector2(210, 500), Color.White);
        }

        private void DrawGameOverScreen()
        {
            spriteBatch.Draw(Graphics.GameOverScreen, rectBackground, Color.White);

            //RenderManager.Instance.SpriteBatch.DrawString(Graphics.Font, "Final Score: " + score, new Vector2(300, 200), Color.White);

            spriteBatch.DrawString(Graphics.Font, ">", new Vector2(325, (int)menuCursor), Color.White);
            spriteBatch.DrawString(Graphics.Font, "Restart", new Vector2(350, 300), Color.White);
            spriteBatch.DrawString(Graphics.Font, "Quit", new Vector2(350, 340), Color.White);
        }

        private void DrawGamePlay(GameTime gameTime)
        {
            this.CurLevel.Draw(gameTime);
        }
    }
}
