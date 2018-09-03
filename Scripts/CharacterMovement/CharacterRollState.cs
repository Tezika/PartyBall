using System;
using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;
using PartyBall.Scripts.Singleton;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterRollState : CharacterMoveState
    {
        private PipeSegment _CachedSegment;

        public CharacterRollState(Character character) : base(character)
        {
        }

        public override MoveType Type
        {
            get
            {
                return MoveType.Roll;
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
            Debugger.Instance.Log("The player is rolling now");
            this.Character.Velocity = new Vector2(this.Character.Velocity.X, -CharacterMoveAbilities.RollFowardSpeed);
            this.Character.Scale = 1;
            this.Character.HorAcceleraltion = CharacterMoveAbilities.RollHorAcceleration;
            _CachedSegment = null;
        }

        public override void OnExit()
        {
            this.CanMoveLeft = true;
            this.CanMoveRight = true;
        }

        public override void Update(GameTime gameTime)
        {
            //Update the pipe segment which the player is landing on now.
            if (_CachedSegment != this.Character.CurPlatform )
            {
                _CachedSegment = this.Character.CurPlatform as PipeSegment;
                if (_CachedSegment == null)
                {
                    throw new System.Exception("Should not get here, check the character roll state");
                }
            }

            if (_CachedSegment == null)
            {
                return;
            }

            var horVelocity = this.Character.Velocity.X;
            var scale = this.Character.Scale;
            var distance = 0.0f;
            var halfCharacterWidth = this.Character.actualCharacterDimensions.X / 2;
            if (_CachedSegment.SegmentType == SegmentType.Middle)
            {
                this.Character.Scale = 1;
                return;
            }
            else if (_CachedSegment.SegmentType == SegmentType.Left)
            {
                //this.CanMoveLeft = false;
                horVelocity += CharacterMoveAbilities.SlopAccereration;
                distance = Math.Abs(_CachedSegment.BoundingBox.Right + halfCharacterWidth  - this.Character.Position.X);
    
            }
            else if (_CachedSegment.SegmentType == SegmentType.Right)
            {
                //this.CanMoveRight = false;
                horVelocity -= CharacterMoveAbilities.SlopAccereration;
                distance = Math.Abs(this.Character.Position.X - halfCharacterWidth - _CachedSegment.BoundingBox.Left);
            }
            horVelocity = MathHelper.Clamp(horVelocity, -CharacterMoveAbilities.MaxiumHorizontalSpeed, CharacterMoveAbilities.MaxiumHorizontalSpeed);
            this.Character.Velocity = new Vector2(horVelocity, this.Character.Velocity.Y);
            this.Character.Scale = MathHelper.Lerp(1, CharacterMoveAbilities.MaxiumSlopeScale, distance / (_CachedSegment.SegmentHeight + halfCharacterWidth));
        }
    }
}
