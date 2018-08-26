using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PartyBall.Scripts.CharacterMovement;
using PartyBall.Scripts.Singleton;
using System;

namespace PartyBall.Scripts.Entities
{
    public class Character : GameObject
    {
        public float CurrentSpeed { get; internal set; }

        public CharacterMoveState CurrentMoveState { get; private set; }

        public CharacterMoveState[] MoveStates { get; private set; }

        public Character(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void Initialize()
        {
            this.InitMoveStates();
        }

        //update the player's logic
        public override void Update(GameTime gameTime)
        {
            this.UpdatePosition(Keyboard.GetState());
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

        public bool CheckLandOnPlatform()
        {
            for (int i = 0; i < Game1.Instance.Platforms.Count; i++)
            {
                var platform = Game1.Instance.Platforms[i];
                if (platform.BoundingBox.Intersects(this.BoundingBox))
                {
                    return true;
                }
            }
            return false;
        }

        public void Respawn()
        {
            Debugger.Instance.Log("The character has already respawned");
            this.CurrentSpeed = CharacterMoveAbilities.RollSpeed;
            this.Scale = 1;
            //Reset the player's 
            this.Position = new Vector2((float)(RenderManager.Instance.Graphics.GraphicsDevice.Viewport.Width * 0.5),
                         (float)(RenderManager.Instance.Graphics.GraphicsDevice.Viewport.Height - this.Height / 2));

            this.TranslateMoveState(MoveType.Roll);
        }


        private void UpdatePosition(KeyboardState state)
        {
            if (!this.CurrentMoveState.CanControl)
            {
                return;
            }

            if (state.IsKeyDown(Keys.Up))
            {
                this.Position = new Vector2(this.Position.X, this.Position.Y - this.CurrentSpeed);
            }

            if (state.IsKeyDown(Keys.Down))
            {
                this.Position = new Vector2(this.Position.X, this.Position.Y + this.CurrentSpeed);
            }

            if (state.IsKeyDown(Keys.Left))
            {
                this.Position = new Vector2(this.Position.X - this.CurrentSpeed, this.Position.Y);
            }

            if (state.IsKeyDown(Keys.Right))
            {
                this.Position = new Vector2(this.Position.X + this.CurrentSpeed, this.Position.Y);
            }

            //Jump
            if (this.CurrentMoveState.CanJump && state.IsKeyDown(Keys.Space))
            {
                this.TranslateMoveState(MoveType.Jump);
            }

            //Check whether the player is on a platform or not.
            if (this.CurrentMoveState.Type == MoveType.Roll || this.CurrentMoveState.Type == MoveType.Slide)
            {
                if(!this.CheckLandOnPlatform())
                {
                    this.TranslateMoveState(MoveType.Fall);
                }
            }
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
    }
}