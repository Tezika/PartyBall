using System;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterRollState : CharacterMoveState
    {
        public CharacterRollState(Character character): base(character)
        {

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
        }

        public override void OnExit()
        {
        }

        public override void Update()
        {
        }
    }
}
