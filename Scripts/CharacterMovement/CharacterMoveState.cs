using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.CharacterMovement
{
    public enum MoveType
    {
        Roll,
        Jump,
        Slide,
        Fall
    }

    public abstract class CharacterMoveState
    {
        public Character Character;

        public abstract MoveType Type { get; }

        public CharacterMoveState(Character character)
        {
            this.Character = character;
        }

        public abstract bool CanControl { get; }

        public abstract bool CanJump { get; }

        public abstract void OnEnter();

        public abstract void OnExit();

        public abstract void Update(GameTime gameTime);

        private bool _CanMoveLeft = true;

        public bool CanMoveLeft
        {
            get
            {
                return _CanMoveLeft;
            }

            protected set
            {
                _CanMoveLeft = value;
            }
        }

        private bool _CanMoveRight = true;

        public bool CanMoveRight
        {
            get
            {
                return _CanMoveRight;
            }
            protected set
            {
                _CanMoveRight = value;
            }
        }
    }

    public static class CharacterMoveAbilities
    {
        public const float RollSpeed = 3.0f;

        //Jump
        public const float HoverSpeed = 1.5f;

        public const float JumpTime = 1.5f;

        public const float HoverTime = 0.4f;

        public const float HoverScale =1.5f;

        public const float JumpDownTime = 0.6f;

        //Fall
        public const float FallTime = 1.0f;

        //Slide
        public const float SlideSpeed = 6.0f;

        public const float WallMoveSpeed = 1.0f;

        public const float SlideEdgeScale = 0.3f;
    }
}
