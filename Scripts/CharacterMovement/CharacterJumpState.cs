using System;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterJumpState : CharacterMoveState
    {

        public override MoveType Type
        {
            get
            {
                return MoveType.Jump;
            }
        }

        public CharacterJumpState(Character character) : base(character)
        {

        }

        public override void OnEnter()
        {
           
        }

        public override void OnExit()
        {
           
        }

        public override void Update()
        {
     
        }
    }
}
