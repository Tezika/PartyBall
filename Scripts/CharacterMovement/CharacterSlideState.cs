using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;
using PartyBall.Scripts.Singleton;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterSlideState : CharacterMoveState
    {
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
