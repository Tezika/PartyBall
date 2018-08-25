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
}
