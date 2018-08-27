using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;
using PartyBall.Scripts.Singleton;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterJumpState : CharacterMoveState
    {
        private float _Timer;

        private float _InitScale;

        public override MoveType Type
        {
            get
            {
                return MoveType.Jump;
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
                return false;
            }
        }

        public CharacterJumpState(Character character) : base(character)
        {
        }

        public override void OnEnter()
        {
            _Timer = 0.0f;
            _InitScale = this.Character.Scale;
            this.Character.CurrentSpeed = CharacterMoveAbilities.HoverSpeed;
        }

        public override void OnExit()
        {
        }
1
        public override void Update(GameTime gameTime)
        {
            //Jump logic, 
            _Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_Timer < CharacterMoveAbilities.JumpTime)
            {
                Debugger.Instance.Log("The character is jumping up now.");
                var amount = _Timer / CharacterMoveAbilities.JumpTime;
                this.Character.Scale = MathHelper.Lerp(_InitScale, CharacterMoveAbilities.HoverScale, amount);
            }
            else if (_Timer >= CharacterMoveAbilities.JumpTime
                    && _Timer < CharacterMoveAbilities.JumpTime + CharacterMoveAbilities.HoverTime)
            {
                Debugger.Instance.Log("The character is hovering now.");
            }
            else if (_Timer >= CharacterMoveAbilities.JumpTime + CharacterMoveAbilities.HoverTime
                    && _Timer < CharacterMoveAbilities.JumpTime + CharacterMoveAbilities.HoverTime + CharacterMoveAbilities.JumpDownTime)
            {
                var amount = (_Timer - CharacterMoveAbilities.JumpTime - CharacterMoveAbilities.HoverTime) / CharacterMoveAbilities.JumpDownTime;
                this.Character.Scale = MathHelper.Lerp(CharacterMoveAbilities.HoverScale, _InitScale, amount);
                Debugger.Instance.Log("The character is jumping down now");
            }
            else
            {
                Debugger.Instance.Log("The character is landing now");
                //Check the player is on the platform 
                this.Character.TranslateMoveState(MoveType.Roll);
            }
        }
    }
}
