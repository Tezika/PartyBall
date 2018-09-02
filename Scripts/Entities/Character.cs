using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PartyBall.Scripts.CharacterMovement;
using PartyBall.Scripts.Render;
using PartyBall.Scripts.Singleton;
using System;
using PartyBall;

namespace PartyBall.Scripts.Entities
{
    public class Character : GameObject
    {
        public CharacterMoveState CurrentMoveState { get; private set; }

        public CharacterMoveState[] MoveStates { get; private set; }

        public Platform CurPlatform { get; private set; }

        public Vector2 Velocity { get; internal set; }

        public float HorAcceleraltion { get; internal set; }

        // Holds which positon of the spriteSheet we are. This means that we are in
        // the first frame of our spriteSheet in our first line of the spriteSheet
        public Point currentFrame = new Point(0, 0);
        // The first int holds the width and the second holds the height, of the single frame we want to see every time
        public Point frameSize = new Point(64, 64);
        // Holds how many frames are on the line and how many lines of frames we have
        public Point sheetSize = new Point(3, 4);
        public Vector2 actualCharacterDimensions = new Vector2(64, 64);
        public Vector2 actualCharacterOrigin = new Vector2(64 / 2, 64 / 2);

        //Animation timer
        private int _TimeSinceLastFrame = 0;

        //Update the animation per 100 millseconds
        private int _MillisecondsPerFrame = 100;

        public Character(Texture2D texture, Vector2 position) : base(position, texture)
        {
        }

        public override void Initialize()
        {
            this.InitMoveStates();
            this.CurPlatform = null;
            this.HorAcceleraltion = CharacterMoveAbilities.RollHorAcceleration;
        }

        //update the player's logic
        public override void Update(GameTime gameTime)
        {
            //The update order matters
            this.UpdateAnimation(gameTime);
            this.UpdatePosition();
            this.UpdatePlatform();
            this.UpdateVelocity(Keyboard.GetState());
            this.UpdatePickups();

            if (this.CurrentMoveState != null)
            {
                this.CurrentMoveState.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void TranslateMoveState(MoveType type)
        {
            if (this.CurrentMoveState != null)
            {
                //if the player has already on that state.
                if (this.CurrentMoveState.Type == type)
                {
                    return;
                }
                this.CurrentMoveState.OnExit();
            }
            this.CurrentMoveState = this.MoveStates[(int)type];
            this.CurrentMoveState.OnEnter();
        }

        public void Spawn()
        {
            Game1.stopWatch.Reset();
            Debugger.Instance.Log("The character has already respawned");
            this.Velocity = new Vector2(0, CharacterMoveAbilities.RollFowardSpeed); 
            this.Scale = 1;
            //Reset the player's position
            this.Position = new Vector2((float)(RenderManager.Instance.Graphics.GraphicsDevice.Viewport.Width * 0.5),
                         (float)(RenderManager.Instance.Graphics.GraphicsDevice.Viewport.Height - this.actualCharacterDimensions.Y / 2));
            this.TranslateMoveState(MoveType.Roll);
        }

        private void UpdatePickups()
        {
            for (int i = 0; i < Game1.Instance.CurLevel.Pickups.Count; i++)
            {
                var curPickup = Game1.Instance.CurLevel.Pickups[i];
                if (curPickup.BoundingBox.Intersects(this.BoundingBox))
                {
                    curPickup.TakeEffect();
                    break;
                }
            }
        }

        private void UpdatePlatform()
        {
            //When player is jumping or  falling, we dont update the platform
            if (this.CurrentMoveState.Type == MoveType.Jump || this.CurrentMoveState.Type == MoveType.Fall)
            {
                return;
            }
            this.CurPlatform = null;
            for (int i = 0; i < Game1.Instance.CurLevel.Platforms.Count; i++)
            {
                var platform = Game1.Instance.CurLevel.Platforms[i];
                if (platform.BoundingBox.Intersects(this.BoundingBox))
                {
                    this.CurPlatform = platform;
                    break;
                }
            }

            if (this.CurPlatform == null)
            {
                this.TranslateMoveState(MoveType.Fall);
                return;
            }

            if (this.CurPlatform.Type == PlatformType.PipeSegment && this.CurrentMoveState.Type != MoveType.Roll)
            {
                this.TranslateMoveState(MoveType.Roll);
            }
            else if (this.CurPlatform.Type == PlatformType.Wall && this.CurrentMoveState.Type != MoveType.Slide)
            {
                this.TranslateMoveState(MoveType.Slide);
            }
        }

        private void UpdateVelocity(KeyboardState state)
        {
            if (!this.CurrentMoveState.CanControl)
            {
                return;
            }

            
            //Jump
            if (this.CurrentMoveState.CanJump && state.IsKeyDown(Keys.Space))
            {
                this.TranslateMoveState(MoveType.Jump);
                this.CurPlatform = null;
            }

            var velocityX = this.Velocity.X;
            //Horizontal Input
            if(this.CurrentMoveState.CanMoveLeft && (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left)))
            {
                velocityX -= this.HorAcceleraltion;
            }

            if (this.CurrentMoveState.CanMoveRight && (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right)))
            {
                velocityX += this.HorAcceleraltion;
            }

            velocityX = MathHelper.Clamp(velocityX, -CharacterMoveAbilities.MaxiumHorizontalSpeed, CharacterMoveAbilities.MaxiumHorizontalSpeed);

            this.Velocity = new Vector2(velocityX, this.Velocity.Y);

        }

        private void UpdateAnimation(GameTime gameTime)
        {
            //determine whether need to update animation or not
            _TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (_TimeSinceLastFrame > _MillisecondsPerFrame)
            {
                _TimeSinceLastFrame -= _MillisecondsPerFrame;
                if (Velocity.Y != 0)
                {
                    //Update the vertical speed
                    currentFrame.X++;
                    if (currentFrame.X >= 3)
                        currentFrame.X = 0;
                }

                var deadZone = 0.4f;

                if (Velocity.X < -deadZone)
                {
                    currentFrame.Y = 4;
                }
                else if (Velocity.X > deadZone)
                {
                    currentFrame.Y = 3;
                }
                else
                {
                    currentFrame.Y = 0;
                }
            }
        }


        private void UpdatePosition()
        {
            this.Position = new Vector2(this.Position.X + this.Velocity.X, this.Position.Y + this.Velocity.Y);
        }

        private void InitMoveStates()
        {
            //set up move states
            if (this.MoveStates == null)
            {
                this.MoveStates = new CharacterMoveState[Enum.GetNames(typeof(MoveType)).Length];
            }

            this.MoveStates[(int)MoveType.Fall] = new CharacterFallState(this);
            this.MoveStates[(int)MoveType.Jump] = new CharacterJumpState(this);
            this.MoveStates[(int)MoveType.Roll] = new CharacterRollState(this);
            this.MoveStates[(int)MoveType.Slide] = new CharacterSlideState(this);
        }

        public override Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)(this.Position.X - this.actualCharacterOrigin.X * this.Scale),
                                     (int)(this.Position.Y - this.actualCharacterOrigin.Y * this.Scale),
                                     (int)(this.actualCharacterDimensions.X * this.Scale),
                                     (int)(this.actualCharacterDimensions.Y * this.Scale));
            }
        }
    }
}