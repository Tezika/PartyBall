using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterFallState : CharacterMoveState
    {
        public float FallTime { get; private set; }

        private float _Timer;

        private float _initScale;

        public CharacterFallState(Character character) : base(character)
        {
            this.FallTime = 5.0f;
        }

        public override MoveType Type
        {
            get
            {
                return MoveType.Fall;
            }
        }

        public override void OnEnter()
        {
            _Timer = 0.0f;
            _initScale = this.Character.Scale;
        }

        public override void OnExit()
        {
            this.Character.Scale = 1;
            
        }

        public override void Update(GameTime gameTime)
        {
            _Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_Timer < this.FallTime)
            {
                var amount = _Timer / this.FallTime;
                this.Character.Scale = MathHelper.Lerp(_initScale, 0, amount);
            }
            else
            {
                _Timer = 0.0f;
                //The player should die now
                this.Character.TranslateMoveState(MoveType.Roll);
            }
        }
    }
}
