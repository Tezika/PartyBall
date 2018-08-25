using Microsoft.Xna.Framework;
using PartyBall.Scripts.Entities;

namespace PartyBall.Scripts.CharacterMovement
{
    public enum MoveType
    {
        Roll,
        Jump,
        Stick,
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

        public abstract void OnEnter();

        public abstract void OnExit();

        public abstract void Update(GameTime gameTime);
    }

    public static class CharacterMoveAbilities
    {
        public const float RollSpeed = 5.0f;

        public const float HoverSpeed = 3.0f;

        public const float JumpTime = 1.0f;

        public const float HoverTime = 2.0f;

        public const float HoverScale = 2.0f;

        public const float JumpDownTime = 1.0f;

        public const float FallTime = 2.0f;
    }
}
