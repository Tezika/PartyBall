using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;
using PartyBall.Scripts.Singleton;

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
            Debugger.Instance.Log("The player is sticking now");
        }

        public override void OnExit()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
