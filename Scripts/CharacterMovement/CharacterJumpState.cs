using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;
using System;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterJumpState : CharacterMoveState
    {
        public float ScaleLimit { get; private set; }

        public float JumpSpeed { get; private set; }

        public float HoverTime { get; private set; }

        private float _Timer;

        private float _ScaleAcceleration;

        public override MoveType Type
        {
            get
            {
                return MoveType.Jump;
            }
        }

        public CharacterJumpState(Character character) : base(character)
        { 
            this.ScaleLimit = 2.0f;
            this.JumpSpeed = 5.0f;
            this.HoverTime = 5.0f;
        }

        public override void OnEnter()
        {
            Console.WriteLine("The character enters the Jump state");
            _Timer = 0.0f;
            _ScaleAcceleration = (this.ScaleLimit - this.Character.Scale) / this.HoverTime;
        }

        public override void OnExit()
        {
            Console.WriteLine("The character exits the Jump state");
        }
1
        public override void Update(GameTime gameTime)
        {
            _Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_Timer <= this.HoverTime)
            {
                this.Character.Scale += _ScaleAcceleration;
            }
            else
            {
                _Timer = 0.0f;
                this.Character.TranslateMoveState(MoveType.Fall);
            }
        }
    }
}
