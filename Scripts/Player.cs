using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace PartyBall.Scripts
{
    public class Player
    {
        public Texture2D playerTexture { get; private set; }

        public Vector2 playerPosition { get; internal set; }

        public bool active { get; private set; }

        public float health { get; private set; }

        public int width {
            get {
                return (this.playerTexture == null ? 0 : this.playerTexture.Width);
            }
        }
        
        public int height {
            get {
                return (this.playerTexture == null ? 0 : this.playerTexture.Height);
            }
        }

        public Player() {
            Console.WriteLine("The player has been initiated");
        }

        public void Initialize(Texture2D texture, Vector2 position) {
            this.playerTexture = texture;
            this.playerPosition = position;
            this.active = true;
            this.health = 100;
            
        }

        //update the player's logic
        public void Update() {
        }


        public void Draw(SpriteBatch batch) {
            batch.Draw(this.playerTexture, 
                this.playerPosition, 
                null, 
                Color.White, 
                0f,
                Vector2.Zero, 
                1f,
                SpriteEffects.None, 
                0f);
       }
    }
}
