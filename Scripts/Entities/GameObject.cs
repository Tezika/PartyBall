using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Entities 
{
    public class GameObject: IUpdateable, IDrawable
    {
        public string Tag { get; private set; }

        public Texture2D Texture { get; private set; }

        public Vector2 Position { get; internal set; }

        public bool Enabled { get; protected set; }

        public int UpdateOrder { get; protected set; }

        public int DrawOrder { get; protected set; }

        public bool Visible { get; protected set; }

        public event EventHandler<EventArgs> EnabledChanged;

        public event EventHandler<EventArgs> UpdateOrderChanged;

        public event EventHandler<EventArgs> DrawOrderChanged;

        public event EventHandler<EventArgs> VisibleChanged;

        public int Width
        {
            get
            {
                return (this.Texture == null ? 0 : this.Texture.Width);
            }
        }

        public int Height
        {
            get
            {
                return (this.Texture == null ? 0 : this.Texture.Height);
            }
        }

        public GameObject(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
            this.Visible = true;
            this.Enabled = true;
        }

        public virtual void Initialize()
        {
        
        }

        public virtual void LoadContent()
        {

        }

        public virtual void UnloadContent()
        {

        }

        public virtual void Draw(GameTime gameTime)
        {

        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}
