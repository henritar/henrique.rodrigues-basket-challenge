using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared.Interfaces.InputSystem;

namespace Assets.Scripts.Runtime.Shared
{
    public abstract class BaseGameplayInputHandler : IGameplayInputHandler
    {
        public abstract GameStatesEnum CurrentGameState { get; }

        public virtual void HandleClick()
        {
        }

        public virtual void HandleHoldClick()
        {
        }

        public virtual void HandlePlainClick()
        {
        }

        public virtual void HandleReleaseClick()
        {
        }
    }
}