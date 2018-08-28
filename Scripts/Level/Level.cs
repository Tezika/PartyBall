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
            this.Character.Respawn();
        }

        public void LoadContent(Game game)
        {
            var content = game.Content;
            var graphicsDevice = game.GraphicsDevice;

            //Load the content
            //Test level layout only by hard coding
            this.Character = new Character(Graphics.Ball, Vector2.Zero);
            var platformScale = 0.4f;
            var wallScale = 0.25f;
            var regPlatform_1 = new RegularPlatform(Graphics.Reg_Platform, Vector2.Zero, platformScale);
            var regPlatform_2 = new RegularPlatform(Graphics.Reg_Platform, Vector2.Zero, platformScale);
            var wall_1 = new Wall(Graphics.Wall_Left, Vector2.Zero, WallSide.Left, wallScale);
            var wall_2 = new Wall(Graphics.Wall_Right, Vector2.Zero, WallSide.Right, wallScale);
            var wall_3 = new Wall(Graphics.Wall_Left, Vector2.Zero, WallSide.Left, wallScale);
            var wall_4 = new Wall(Graphics.Wall_Right, Vector2.Zero, WallSide.Right, wallScale);
            var testPickup = new TestPickUp(Graphics.ShadesPickup, Vector2.Zero);

            var layoutHeight = regPlatform_1.Height * regPlatform_2.Scale;

            regPlatform_1.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                 (float)(graphicsDevice.Viewport.Height - 0.5 * layoutHeight));

            wall_1.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.2),
                                               (float)(graphicsDevice.Viewport.Height - 1.7 * layoutHeight));

            wall_2.Position = new Vector2((float)(graphicsDevice.Viewport.Width),
                                             (float)(graphicsDevice.Viewport.Height - 1.7 * layoutHeight));


            regPlatform_2.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                       (float)(graphicsDevice.Viewport.Height - 2.7 * layoutHeight));


            wall_3.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.2),
                                               (float)(graphicsDevice.Viewport.Height - 4 * layoutHeight));

            wall_4.Position = new Vector2((float)(graphicsDevice.Viewport.Width),
                                             (float)(graphicsDevice.Viewport.Height - 4.6 * layoutHeight));


            testPickup.Position = new Vector2((float)(graphicsDevice.Viewport.Width * 0.5),
                                                       (float)(graphicsDevice.Viewport.Height - 5.3 * layoutHeight));

            this.Platforms.Add(regPlatform_1);
            this.Platforms.Add(regPlatform_2);

            this.Platforms.Add(wall_1);
            this.Platforms.Add(wall_2);
            this.Platforms.Add(wall_3);
            this.Platforms.Add(wall_4);

            this.Pickups.Add(testPickup);

            this.GameObjects.Add(this.Character);
            this.GameObjects.AddRange(this.Platforms);
            this.GameObjects.AddRange(this.Pickups);
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
            this.Camera.FollowCharacter(this.Character);
        }
    }
}
