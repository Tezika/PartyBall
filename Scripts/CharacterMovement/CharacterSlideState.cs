using System;
using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;
using PartyBall.Scripts.Singleton;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterSlideState : CharacterMoveState
    {
        public enum SlideDirection
        {
            Left,
            Right
        }

        private SlideDirection _SlideDirection = SlideDirection.Left;

        private Wall _CurWall;

        private float _SlideTime;

        private float _InitScale;

        private float _Timer;

        public CharacterSlideState(Character character) : base(character)
        {
        }

        public override MoveType Type
        {
            get
            {
                return MoveType.Slide;
            }
        }

        public override bool CanControl
        {
            get
            {
                return true;
            }
        }

        public override bool CanJump
        {
            get
            {
                return true;
            }
        }

        public override void OnEnter()
        {
            Debugger.Instance.Log("The player is sliding now");
            this.CanMoveLeft = false;
            this.CanMoveRight = false;
            this.Character.CurrentSpeed = CharacterMoveAbilities.WallMoveSpeed;
            _CurWall = this.Character.CurPlatform as Wall;
            if (_CurWall.Side == WallSide.Left)
            {
                _SlideDirection = SlideDirection.Right;
                _SlideTime = Math.Abs(_CurWall.BoundingBox.Right + this.Character.Width / 2 - this.Character.Position.X) / CharacterMoveAbilities.SlideSpeed;
            }
            else
            {
                _SlideDirection = SlideDirection.Left;
                _SlideTime = Math.Abs(this.Character.Position.X + this.Character.Width / 2 - _CurWall.BoundingBox.Left) / CharacterMoveAbilities.SlideSpeed;
            }

            //Scale Stuff
            _InitScale = this.Character.Scale;

            _Timer = 0.0f;
        }

        public override void OnExit()
        {
            this.CanMoveLeft = true;
            this.CanMoveRight = true;
            this.Character.CurrentSpeed = CharacterMoveAbilities.RollSpeed;
            _CurWall = null;
        }

        public override void Update(GameTime gameTime)
        {
            _Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_Timer < _SlideTime)
            {
                var positionX = 0.0f;
                var amount = _Timer / _SlideTime;
                //Why doesn't it work?
                //this.Character.Scale = MathHelper.Lerp(_InitScale, 0, amount);
                if (_SlideDirection == SlideDirection.Left)
                {
                    positionX = MathHelper.Lerp(this.Character.Position.X, _CurWall.BoundingBox.Left - this.Character.Width/2 - 2.0f, amount);
                }
                else
                {
                    positionX = MathHelper.Lerp(this.Character.Position.X, _CurWall.BoundingBox.Right + this.Character.Width/2 + 2.0f, amount);
                }
                this.Character.Position = new Vector2(positionX, this.Character.Position.Y);
            }
            else
            {
                this.Character.TranslateMoveState(MoveType.Fall);
            }
        }
    }
}
