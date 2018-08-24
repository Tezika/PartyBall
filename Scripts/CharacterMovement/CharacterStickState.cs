using System;
using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterStickState : CharacterMoveState
    {
        public CharacterStickState(Character character) : base(character)
        {
        }

        public override MoveType Type
        {
            get
            {
                return MoveType.Stick;
            }
        }
        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
