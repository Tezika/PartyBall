using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace PartyBall.Scripts.Entities
{
    public class Character : GameObject
    {
        public float Speed { get; internal set; }

        public Character(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void Initialize()
        {
            this.Speed = 10.0f;
        }

        //update the player's logic
        public override void Update(GameTime gameTime)
        {
            this.UpdatePosition(Keyboard.GetState());
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        private void UpdatePosition(KeyboardState state)
        {
            Console.WriteLine("Update the character's position.");
            if (state.IsKeyDown(Keys.Up))
            {
                this.Position = new Vector2(this.Position.X, this.Position.Y - this.Speed);
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.Position = new Vector2(this.Position.X, this.Position.Y + this.Speed);
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                this.Position = new Vector2(this.Position.X - this.Speed, this.Position.Y);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.Position = new Vector2(this.Position.X + this.Speed, this.Position.Y);
            }
        }
    }
}
