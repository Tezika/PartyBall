using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PartyBall.Scripts.Entities
{
    public class GameObject : IUpdateable, IDrawable
    {
        public string Tag { get; private set; }

        public Texture2D Texture { get; private set; }

        public Vector2 Position { get; internal set; }

        public bool Enabled { get; protected set; }

        public int UpdateOrder { get; protected set; }

        public int DrawOrder { get; protected set; }

        public bool Visible { get; protected set; }

        public float Scale { get; set; }

        public event EventHandler<EventArgs> EnabledChanged;

        public event EventHandler<EventArgs> UpdateOrderChanged;

        public event EventHandler<EventArgs> DrawOrderChanged;

        public event EventHandler<EventArgs> VisibleChanged;

        public float TextureRatio { get; set; }

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

        public Vector2 Origin
        {
            get
            {
                return new Vector2(this.Width / 2, this.Height / 2);
            }
        }

        virtual public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)(this.Position.X - this.Origin.X * this.Scale),
                                     (int)(this.Position.Y - this.Origin.Y * this.Scale),
                                     (int)(this.Width * this.Scale),
                                     (int)(this.Height * this.Scale));
            }
        }

        public GameObject(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
            this.Visible = true;
            this.Enabled = true;
            this.Scale = 1.0f;
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
