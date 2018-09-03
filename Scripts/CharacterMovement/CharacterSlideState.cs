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
            //Scale Stuff
            _InitScale = this.Character.Scale;
            this.Character.Scale = 1.0f;

            this.Character.Velocity = new Vector2(this.Character.Velocity.X, -CharacterMoveAbilities.WallMoveSpeed);
            _CurWall = this.Character.CurPlatform as Wall;
            if (_CurWall.Side == WallSide.Left)
            {
                var distance = Math.Abs(_CurWall.BoundingBox.Right + this.Character.actualCharacterDimensions.X / 2 - this.Character.Position.X);
                _SlideDirection = SlideDirection.Right;
                _SlideTime = distance / CharacterMoveAbilities.SlideSpeed;
            }
            else
            {
                var distance = Math.Abs(this.Character.Position.X + this.Character.actualCharacterDimensions.X / 2 - _CurWall.BoundingBox.Left);
                _SlideDirection = SlideDirection.Left;
                _SlideTime = distance / CharacterMoveAbilities.SlideSpeed;
            }

            _Timer = 0.0f;
        }

        public override void OnExit()
        {
            this.CanMoveLeft = true;
            this.CanMoveRight = true;
            this.Character.Velocity = new Vector2(0, -CharacterMoveAbilities.RollFowardSpeed);
            _CurWall = null;
        }

        public override void Update(GameTime gameTime)
        {

            _Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_Timer < _SlideTime)
            {
                var positionX = 0.0f;
                var amount = _Timer / _SlideTime;
                //Why doesn't it work? The factor is mysterious???
                this.Character.Scale = MathHelper.Lerp(_InitScale, CharacterMoveAbilities.SlideEdgeScale, amount * 5);
                if (_SlideDirection == SlideDirection.Left)
                {
                    positionX = MathHelper.Lerp(this.Character.Position.X, _CurWall.BoundingBox.Left - this.Character.actualCharacterDimensions.X / 2 - 2.0f, amount);
                }
                else
                {
                    positionX = MathHelper.Lerp(this.Character.Position.X, _CurWall.BoundingBox.Right + this.Character.actualCharacterDimensions.X / 2 + 2.0f, amount);
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
