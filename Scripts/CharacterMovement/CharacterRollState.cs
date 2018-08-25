using System;
using Microsoft.Xna.Framework;
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
            this.Character.CurrentSpeed = CharacterMoveAbilities.RollSpeed;
        }

        public override void OnExit()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
