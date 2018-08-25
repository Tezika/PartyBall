using System;
using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterRollState : CharacterMoveState
    {
        private float _timer;

        public CharacterRollState(Character character): base(character)
        {
            _timer = 0.0f;
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
            Console.WriteLine("PB: The character enter the roll state.");
        }

        public override void OnExit()
        {
            Console.WriteLine("PB: The character exit the roll state.");
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
