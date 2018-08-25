using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;

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

        public override void Update(GameTime gameTime)
        {
            _Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_Timer < CharacterMoveAbilities.HoverTime)
            {
                var amount = _Timer / CharacterMoveAbilities.HoverTime;
                this.Character.Scale = MathHelper.Lerp(_InitScale, CharacterMoveAbilities.HoverScale, amount);
            }
            else
            {

                _Timer = 0.0f;
                this.Character.TranslateMoveState(MoveType.Fall);
            }
        }
    }
}
