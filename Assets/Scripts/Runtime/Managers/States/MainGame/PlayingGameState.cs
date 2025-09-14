using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.EventBus.Events;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.InputSystem.Gameplay;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers.States.MainGame
{
    public class PlayingGameState : BaseGameState
    {
        private readonly IEventBus _eventBus;
        private readonly IBallPresenter _ballPresenter;
        private readonly IPlayingInputHandler _inputHandler;
        private readonly IGameplayInputManager _inputManager;

        protected override GameStatesEnum GameState => GameStatesEnum.Playing;

        public PlayingGameState(IEventBus eventBus, IBallPresenter ballPresenter, IPlayingInputHandler inputHandler, IGameplayInputManager inputManager)
        {
            _eventBus = eventBus;
            _ballPresenter = ballPresenter;
            _inputHandler = inputHandler;
            _inputManager = inputManager;
        }

        protected override void OnEnterState()
        {
            Debug.Log("Entering Playing Game State");
            _inputManager.SetCurrentInputHandler(_inputHandler);
            _inputHandler.OnReleaseClick += FireShotEvent;
        }

        protected override void OnExitState()
        {
            _inputHandler.OnReleaseClick -= FireShotEvent;
            _inputManager.SetCurrentInputHandler(null);
            Debug.Log("Exiting Playing Game State");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnFixedUpdate()
        {
        }

        public void FireShotEvent()
        {
            _eventBus.Publish(new ShotEvent(_ballPresenter, ShotResultEnum.BackboardBasket));
        }
    }
}