using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.InputSystem.Gameplay;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using System;

namespace Assets.Scripts.Runtime.InputSystem.Gameplay
{
    public class Gameplay_PlayingInputHandler : BaseGameplayInputHandler, IPlayingInputHandler
    {
        public override GameStatesEnum CurrentGameState => GameStatesEnum.Playing;
        public IBallPresenter BallPresenter { get; set; }
        public event Action<IBallPresenter> OnHoldClick;
        public event Action OnReleaseClick;
        public override void HandleHoldClick()
        { 
            OnHoldClick?.Invoke(BallPresenter);
        }
        public override void HandleReleaseClick()
        {
            OnReleaseClick?.Invoke();
        }
    }
}