using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;
using PartyBall.Scripts.Singleton;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterFallState : CharacterMoveState
    {
        private float _Timer;

        private float _initScale;

        public CharacterFallState(Character character) : base(character)
        {
        }

        public override MoveType Type
        {
            get
            {
                return MoveType.Fall;
            }
        }

        public override bool CanControl
        {
            get
            {
                return false;
            }
        }

        public override bool CanJump
        {
            get
            {
                return false;
            }
        }

        public override void OnEnter()
        {
            Debugger.Instance.Log("The player is falling now");
            _Timer = 0.0f;
            _initScale = this.Character.Scale;
        }

        public override void OnExit()
        {
        }

        public override void Update(GameTime gameTime)
        {
            _Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_Timer < CharacterMoveAbilities.FallTime)
            {
                var amount = _Timer / CharacterMoveAbilities.FallTime;
                this.Character.Scale = MathHelper.Lerp(_initScale, 0, amount);
            }
            else
            {
                _Timer = 0.0f;
                //The player should die now
                this.Character.Respawn();
            }
        }
    }
}
