﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PartyBall.Scripts.Entities;
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

        public Character Character;

        public RegularPlatform RegPlatform_1;

        public RegularPlatform RegPlatform_2;

        public Wall Wall_1;

        public Wall Wall_2;

        public Camera Camera { get; private set; }

        public List<Platform> Platforms = new List<Platform>();

        public Game1()
        {
            RenderManager.Instance.Graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            Game1.Instance = this;
            this.Camera = new Camera();
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
            this.Character.Initialize();
            this.Character.Respawn();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            this.Platforms.Clear();

            // Create a new SpriteBatch, which can be used to draw textures.
            RenderManager.Instance.Setup(this);
            Debugger.Instance.Setup(this);

            // TODO: use this.Content to load your game content here
            // Load the player resources
            this.Character = new Character(Content.Load<Texture2D>("texture//character"), Vector2.Zero);

            //Load the test platforms
            this.RegPlatform_1 = new RegularPlatform(Content.Load<Texture2D>("texture//platform_reg"), Vector2.Zero);
            this.RegPlatform_2 = new RegularPlatform(Content.Load<Texture2D>("texture//platform_reg"), Vector2.Zero);
            this.Wall_1 = new Wall(Content.Load<Texture2D>("texture//wall_left"), Vector2.Zero, WallSide.Left);
            this.Wall_2 = new Wall(Content.Load<Texture2D>("texture//wall_right"), Vector2.Zero, WallSide.Right);

            this.RegPlatform_1.Position = new Vector2((float)(GraphicsDevice.Viewport.Width * 0.5),
                                               (float)(GraphicsDevice.Viewport.Height - this.RegPlatform_1.Height / 2));

            this.Wall_1.Position = new Vector2((float)(GraphicsDevice.Viewport.Width * 0.2),
                                               (float)(GraphicsDevice.Viewport.Height -  1.43 * this.RegPlatform_1.Height));

            this.Wall_2.Position = new Vector2((float)(GraphicsDevice.Viewport.Width * 0.9),
                                             (float)(GraphicsDevice.Viewport.Height - 1.43 * this.RegPlatform_1.Height));


            this.RegPlatform_2.Position = new Vector2((float)(GraphicsDevice.Viewport.Width * 0.5),
                                                       (float)(GraphicsDevice.Viewport.Height - 3 * this.RegPlatform_1.Height));

            this.Platforms.Add(this.RegPlatform_1);
            this.Platforms.Add(this.RegPlatform_2);
            this.Platforms.Add(this.Wall_1);
            this.Platforms.Add(this.Wall_2);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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
            this.Character.Update(gameTime);
            this.Camera.FollowCharacter(this.Character);
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
           
            RenderManager.Instance.DrawGameObject(this.RegPlatform_2);
            RenderManager.Instance.DrawGameObject(this.RegPlatform_1);
            RenderManager.Instance.DrawGameObject(this.Wall_1);
            RenderManager.Instance.DrawGameObject(this.Wall_2);
            RenderManager.Instance.DrawGameObject(this.Character);

            Debugger.Instance.DrawDebugInfo();

            //Draw title!!!
            RenderManager.Instance.DrawString("PartyBaller", Debugger.Instance.Font, new Vector2((float)0.4 * RenderManager.Instance.Graphics.GraphicsDevice.Viewport.Width,
                                                                                                  (float)0.01 * RenderManager.Instance.Graphics.GraphicsDevice.Viewport.Height));
            base.Draw(gameTime);
        }
    }
}
