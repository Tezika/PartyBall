using System;
using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterRollState : CharacterMoveState
    {
        private float _rollSpeed;

        public CharacterRollState(Character character): base(character)
        {
            _rollSpeed = 5.0f;
        }

        public override MoveType Type
        {
            get
            {
                return MoveType.Roll;
            }
        }

        public override void OnEnter()
        {
            this.Character.CurrentSpeed = _rollSpeed;
        }

        public override void OnExit()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
