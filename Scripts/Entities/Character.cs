﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PartyBall.Scripts.CharacterMovement;
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
            this.CurrentSpeed = 5.0f;
            this.InitMoveStates();
            this.Scale = 1.0f;
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

        private void UpdatePosition(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Up))
            {
                this.Position = new Vector2(this.Position.X, this.Position.Y - this.CurrentSpeed);
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                this.Position = new Vector2(this.Position.X, this.Position.Y + this.CurrentSpeed);
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                this.Position = new Vector2(this.Position.X - this.CurrentSpeed, this.Position.Y);
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                this.Position = new Vector2(this.Position.X + this.CurrentSpeed, this.Position.Y);
            }

            if (state.IsKeyDown(Keys.Space))
            {
                this.TranslateMoveState(MoveType.Jump);
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
            this.MoveStates[(int)MoveType.Stick] = new CharacterStickState(this);

            this.TranslateMoveState(MoveType.Roll);
        }
    }
}