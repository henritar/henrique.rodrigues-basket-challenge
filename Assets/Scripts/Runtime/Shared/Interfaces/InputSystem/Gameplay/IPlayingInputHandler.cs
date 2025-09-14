using System;

namespace Assets.Scripts.Runtime.Shared.Interfaces.InputSystem.Gameplay
{
    public interface IPlayingInputHandler : IGameplayInputHandler
    {
        event Action OnHoldClick;
        event Action OnReleaseClick;
    }
}