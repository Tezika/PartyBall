using System.Collections.Generic;
using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;
using PartyBall.Scripts.Entities.Pickups;
using PartyBall.Scripts.Render;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Level
{
    public class Level
    {
        public List<GameObject> GameObjects { get; private set; }

        public List<Platform> Platforms { get; private set; }

        public List<Pickup> Pickups { get; private set; }

        public Character Character { get; private set; }

        public Camera Camera { get; private set; }

        public Level()
        {
            this.GameObjects = new List<GameObject>();
            this.Platforms = new List<Platform>();
            this.Pickups = new List<Pickup>();
            this.Camera = new Camera();
        }

        public void Initialize()
        {
            this.Character.Initialize();
            this.Character.Spawn();
        }

        public void LoadContent(Game game)
        {
            var graphicsDevice = game.GraphicsDevice;

            //Load the content
            //Test level layout only by hard coding
            var layoutHeight = (float)(Graphics.Pipe.Height * 0.4);
            this.Character = new Character(Graphics.Ball, Vector2.Zero);

            this.LayoutPipes(graphicsDevice, 0.4f, layoutHeight);
            this.LayoutWalls(graphicsDevice, 0.25f, layoutHeight);
            this.LayoutPickup(graphicsDevice, 1.0f, layoutHeight);

            this.GameObjects.Add(this.Character);
            this.GameObjects.AddRange(this.Pickups);
            this.GameObjects.AddRange(this.Platforms);
        }

        public void UnloadContent()
        {
            this.Pickups.Clear();
            this.Platforms.Clear();
            this.GameObjects.Clear();
        }

        public void Draw(GameTime gameTime)
        {
            //Draw the game background
            RenderManager.Instance.SpriteBatch.Begin();
            RenderManager.Instance.SpriteBatch.Draw(Graphics.BgScreen, RenderManager.Instance.RectBackground, Color.White);
            RenderManager.Instance.SpriteBatch.End();
            //Draw all the game objects here
            //First for pickups
            for (int i = 0; i < this.Pickups.Count; i++)
            {
                RenderManager.Instance.DrawGameObject(this.Pickups[i]);
            }
            //Then for the platform
            for (int i = 0; i < this.Platforms.Count; i++)
            {
                RenderManager.Instance.DrawGameObject(this.Platforms[i]);
            }
            //The last for the character
            RenderManager.Instance.DrawGameObject(this.Character);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < this.GameObjects.Count; i++)
            {
                this.GameObjects[i].Update(gameTime);
            }
            this.Camera.Update(gameTime ,this.Character);
        }

        private void LayoutPipes(GraphicsDevice graphicsDevice, float scale, float layoutHeight)
        {
            var pipe_1 = new Pipe(Graphics.Pipe, Vector2.Zero, scale);
            var pipe_2 = new Pipe(Graphics.Pipe, Vector2.Zero, scale);

            var pipe_3 = new Pipe(Graphics.Pipe, Vector2.Zero, scale);
            var pipe_4 = new Pipe(Graphics.Pipe, Vector2.Zero, scale);

            var pipe_5 = new Pipe(Graphics.Pipe, Vector2.Zero, scale);
            var pipe_6 = new Pipe(Graphics.Pipe, Vector2.Zero, scale);

            var pipe_7 = new Pipe(Graphics.Pipe, Vector2.Zero, scale);

            var pipe_8 = new Pipe(Graphics.Pipe, Vector2.Zero, scale);
            var pipe_9 = new Pipe(Graphics.Pipe, Vector2.Zero, scale);

            var pipe_10 = new Pipe(Graphics.Pipe, Vector2.Zero, scale);
            var pipe_11 = new Pipe(Graphics.Pipe, Vector2.Zero, scale);
            var pipe_12 = new Pipe(Graphics.Pipe, Vector2.Zero, scale);


            pipe_1.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                 (float)(graphicsDevice.Viewport.Height - 0.5 * layoutHeight));

            pipe_2.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                       (float)(graphicsDevice.Viewport.Height - 1.5 * layoutHeight));

            pipe_3.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                          (float)(graphicsDevice.Viewport.Height - 2.9 * layoutHeight));

            pipe_4.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                       (float)(graphicsDevice.Viewport.Height - 3.9 * layoutHeight));

            pipe_5.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                        (float)(graphicsDevice.Viewport.Height - 5.5 * layoutHeight));

            pipe_6.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                       (float)(graphicsDevice.Viewport.Height - 6.5 * layoutHeight));

            pipe_7.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                      (float)(graphicsDevice.Viewport.Height - 8.1 * layoutHeight));

            pipe_8.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                  (float)(graphicsDevice.Viewport.Height - 9.7 * layoutHeight));

            pipe_9.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                  (float)(graphicsDevice.Viewport.Height - 10.7 * layoutHeight));


            pipe_10.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                (float)(graphicsDevice.Viewport.Height - 13.3 * layoutHeight));


            pipe_11.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                (float)(graphicsDevice.Viewport.Height - 15.6 * layoutHeight));

            pipe_12.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                           (float)(graphicsDevice.Viewport.Height - 18 * layoutHeight));

            this.Platforms.Add(pipe_1);
            this.Platforms.Add(pipe_2);
            this.Platforms.Add(pipe_3);
            this.Platforms.Add(pipe_4);
            this.Platforms.Add(pipe_5);
            this.Platforms.Add(pipe_6);
            this.Platforms.Add(pipe_7);
            this.Platforms.Add(pipe_8);
            this.Platforms.Add(pipe_9);
            this.Platforms.Add(pipe_10);
            this.Platforms.Add(pipe_11);
            this.Platforms.Add(pipe_12);
        }

        private void LayoutWalls(GraphicsDevice graphicsDevice, float scale, float layoutHeight)
        {
            var wall_1 = new Wall(Graphics.Wall_Left, Vector2.Zero, WallSide.Left, scale);
            var wall_2 = new Wall(Graphics.Wall_Right, Vector2.Zero, WallSide.Right, scale);
            var wall_3 = new Wall(Graphics.Wall_Left, Vector2.Zero, WallSide.Left, scale);
            var wall_4 = new Wall(Graphics.Wall_Right, Vector2.Zero, WallSide.Right, scale);

            var wall_5 = new Wall(Graphics.Wall_Left, Vector2.Zero, WallSide.Left, scale);
            var wall_6 = new Wall(Graphics.Wall_Right, Vector2.Zero, WallSide.Right, scale);


            wall_1.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.2),
                                               (float)(graphicsDevice.Viewport.Height - 12 * layoutHeight));

            wall_2.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.8),
                                             (float)(graphicsDevice.Viewport.Height - 12 * layoutHeight));

            wall_3.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.2),
                                             (float)(graphicsDevice.Viewport.Height - 14.5 * layoutHeight));
                                        
            wall_4.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.8),
                                             (float)(graphicsDevice.Viewport.Height - 16.8 * layoutHeight));

            wall_5.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.2),
                                           (float)(graphicsDevice.Viewport.Height - 19.2 * layoutHeight));

            wall_6.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.8),
                                         (float)(graphicsDevice.Viewport.Height - 19.9 * layoutHeight));


            this.Platforms.Add(wall_1);
            this.Platforms.Add(wall_2);
            this.Platforms.Add(wall_3);
            this.Platforms.Add(wall_4);
            this.Platforms.Add(wall_5);
            this.Platforms.Add(wall_6);
        }

        private void LayoutPickup(GraphicsDevice graphicsDevice, float scale, float layoutHeight)
        {
            var shadesPickup = new TestPickUp(Graphics.ShadesPickup, Vector2.Zero);

            shadesPickup.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                       (float)(graphicsDevice.Viewport.Height - 20.6 * layoutHeight));

            this.Pickups.Add(shadesPickup);

        }
    }
}
