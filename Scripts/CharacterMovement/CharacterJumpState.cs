using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.CharacterMovement
{
    public class CharacterJumpState : CharacterMoveState
    {
        public float ScaleLimit { get; private set; }

        public float HoverTime { get; private set; }

        private float _Timer;

        private float _initScale;

        public override MoveType Type
        {
            get
            {
                return MoveType.Jump;
            }
        }

        public CharacterJumpState(Character character) : base(character)
        {
            this.ScaleLimit = 2.0f;
            this.HoverTime = 3.0f;
        }

        public override void OnEnter()
        {
            _Timer = 0.0f;
            _initScale = this.Character.Scale;
            this.Character.CurrentSpeed = 2.0f;
        }

        public override void OnExit()
        {
        }

        public override void Update(GameTime gameTime)
        {
            _Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_Timer < this.HoverTime)
            {
                var amount = _Timer / this.HoverTime;
                this.Character.Scale = MathHelper.Lerp(_initScale, this.ScaleLimit, amount);
            }
            else
            {

                _Timer = 0.0f;
                this.Character.TranslateMoveState(MoveType.Fall);
            }
        }
    }
}
