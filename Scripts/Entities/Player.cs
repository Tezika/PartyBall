using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace PartyBall.Scripts.Entities
{
    public class Player : GameObject
    {
        public Texture2D texture { get; private set; }

        public Vector2 position { get; internal set; }

        public bool active { get; private set; }

        public float health { get; private set; }

        public KeyboardState keyboardState { get; private set; }

        public int width
        {
            get
            {
                return (this.texture == null ? 0 : this.texture.Width);
            }
        }

        public int height
        {
            get
            {
                return (this.texture == null ? 0 : this.texture.Height);
            }
        }

        public float moveSpeed { get; set; }

        public Player(): base()
        {
            Console.WriteLine("The player has been initiated");
        }

        public override void Initialize(Texture2D texture, Vector2 position)
        {
            base.Initialize(texture, position);
            this.texture = texture;
            this.position = position;
            this.active = true;
            this.health = 100;
            this.moveSpeed = 10.0f;
        }

        //update the player's logic
        public void Update()
        {
            this.UpdatePosition(Keyboard.GetState());
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(this.texture,
                this.position,
                null,
                Color.White,
                0f,
                Vector2.Zero,
                1f,
                SpriteEffects.None,
                0f);
            base.Draw(batch);
        }

        private void  UpdatePosition(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Up))
            {
                this.position = new Vector2(this.position.X, this.position.Y - this.moveSpeed);
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.position = new Vector2(this.position.X, this.position.Y + this.moveSpeed);
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                this.position = new Vector2(this.position.X - this.moveSpeed, this.position.Y);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.position = new Vector2(this.position.X + this.moveSpeed, this.position.Y);
            }
        }
    }
}
