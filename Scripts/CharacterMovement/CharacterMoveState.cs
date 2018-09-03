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
        //Jump
        public const float JumpTime = 0.25f;

        public const float HoverTime = 0.25f;

        public const float HoverScale = 1.8f;

        public const float JumpDownTime = 0.2f;

        //Fall
        public const float FallTime = 1.0f;

        //Slide
        public const float SlideSpeed = 7.0f;

        public const float WallMoveSpeed = 4.0f;

        public const float SlideEdgeScale = 0.3f;

        public const float InitAccerleratedTime = 2.0f;

        // Movement
        public const float RollHorAcceleration = 0.2f;

        public const float JumpHorAcceleration = 0.15f;

        public const float MaxiumHorizontalSpeed = 4.0f;

        public const float RollFowardSpeed = 5f;

        //Rolling
        public const float SlopAccereration = 0.08f;

        public const float MaxiumSlopeScale = 1.5f;
    }
}
