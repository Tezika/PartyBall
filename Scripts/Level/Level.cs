using System.Collections.Generic;
using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;
using PartyBall.Scripts.Entities.Pickups;
using PartyBall.Scripts.Render;
using Microsoft.Xna.Framework.Graphics;
using PartyBall.Scripts.Entities.Platforms;

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
            var layoutHeight = (float)(Graphics.PipeSegment_Middle.Height * 0.12f);
            this.Character = new Character(Graphics.Ball, Vector2.Zero);

            this.LayoutPipes(graphicsDevice, layoutHeight);
            this.LayoutWalls(graphicsDevice, 0.25f, layoutHeight);
            this.LayoutPickup(graphicsDevice, 0.125f, layoutHeight);

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
            RenderManager.Instance.DrawCharacter(this.Character);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < this.GameObjects.Count; i++)
            {
                this.GameObjects[i].Update(gameTime);
            }
            this.Camera.Update(gameTime ,this.Character);
        }

        private void LayoutPipes(GraphicsDevice graphicsDevice, float layoutHeight)
        {
            var pipe_1 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                 (float)(graphicsDevice.Viewport.Height - 0.5 * layoutHeight)));

            var pipe_2 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                              (float)(graphicsDevice.Viewport.Height - 1.5 * layoutHeight)));

            var pipe_0 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                            (float)(graphicsDevice.Viewport.Height - 2.5 * layoutHeight)));

            var pipe_3 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                              (float)(graphicsDevice.Viewport.Height - 4 * layoutHeight)));

            var pipe_4 = new Pipe (new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                               (float)(graphicsDevice.Viewport.Height - 5 * layoutHeight)), middle: false);

            var pipe_5 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                              (float)(graphicsDevice.Viewport.Height - 6 * layoutHeight)));

            var pipe_6 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                              (float)(graphicsDevice.Viewport.Height - 7 * layoutHeight)), right: false);

            var pipe_7 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                               (float)(graphicsDevice.Viewport.Height - 8 * layoutHeight)));

            var pipe_8 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                              (float)(graphicsDevice.Viewport.Height - 9 * layoutHeight)), left:false);

            var pipe_9 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                             (float)(graphicsDevice.Viewport.Height - 10.6 * layoutHeight)));

            var pipe_10 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                               (float)(graphicsDevice.Viewport.Height - 13.3 * layoutHeight)));

            var pipe_11 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                               (float)(graphicsDevice.Viewport.Height - 15.6 * layoutHeight)));

            var pipe_12 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                               (float)(graphicsDevice.Viewport.Height - 18 * layoutHeight)));                           

            var pipe_14 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                               (float)(graphicsDevice.Viewport.Height  -  19 * layoutHeight)));

            var pipe_15 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                               (float)(graphicsDevice.Viewport.Height - 20 * layoutHeight)), middle:false);

            var pipe_16 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                               (float)(graphicsDevice.Viewport.Height - 21 * layoutHeight)), left:false);

            var pipe_17 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                               (float)(graphicsDevice.Viewport.Height - 22 * layoutHeight)), right:false);

            var pipe_18 = new Pipe(new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                              (float)(graphicsDevice.Viewport.Height - 23 * layoutHeight)));
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
                                           (float)(graphicsDevice.Viewport.Height - 24.1 * layoutHeight));

            wall_6.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.8),
                                         (float)(graphicsDevice.Viewport.Height - 25.2 * layoutHeight));


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

            shadesPickup.Scale = scale;
            shadesPickup.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                       (float)(graphicsDevice.Viewport.Height - 26.2 * layoutHeight));

            this.Pickups.Add(shadesPickup);

        }
    }
}
