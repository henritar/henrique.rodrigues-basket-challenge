using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.InputSystem.Gameplay;
using System;
using UnityEngine;

namespace Assets.Scripts.Runtime.InputSystem.Gameplay
{
    public class Gameplay_PlayingInputHandler : BaseGameplayInputHandler, IPlayingInputHandler
    {
        public override GameStatesEnum CurrentGameState => GameStatesEnum.Playing;
        public event Action OnHoldClick;
        public event Action OnReleaseClick;
        public override void HandleHoldClick()
        { 
            Debug.Log("Hold Clicked in Playing State");
            OnHoldClick?.Invoke();
        }
        public override void HandleReleaseClick()
        {
            Debug.Log("Released Clicked in Playing State");
            OnReleaseClick?.Invoke();
        }
    }
}