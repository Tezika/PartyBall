using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;
using PartyBall.Scripts.Singleton;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterRollState : CharacterMoveState
    {
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
