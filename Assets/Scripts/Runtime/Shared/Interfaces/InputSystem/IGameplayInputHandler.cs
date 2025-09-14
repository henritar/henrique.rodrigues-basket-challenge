using Assets.Scripts.Runtime.Enums;

namespace Assets.Scripts.Runtime.Shared.Interfaces.InputSystem
{
    public interface IGameplayInputHandler : IInputHandler
    {
        GameStatesEnum CurrentGameState { get; }
        void HandlePlainClick();
        void HandleHoldClick();
        void HandleReleaseClick();
    }
}