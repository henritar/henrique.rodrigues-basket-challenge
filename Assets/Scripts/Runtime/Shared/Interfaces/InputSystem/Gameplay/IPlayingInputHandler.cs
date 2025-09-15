using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using System;

namespace Assets.Scripts.Runtime.Shared.Interfaces.InputSystem.Gameplay
{
    public interface IPlayingInputHandler : IGameplayInputHandler
    {
        IBallPresenter BallPresenter { get; set; }
        event Action<IBallPresenter> OnHoldClick;
        event Action OnReleaseClick;
    }
}