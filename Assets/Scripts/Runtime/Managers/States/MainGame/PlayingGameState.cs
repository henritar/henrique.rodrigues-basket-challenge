using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.EventBus.Events;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers.States.MainGame
{
    public class PlayingGameState : BaseGameState
    {
        private IEventBus _eventBus;
        private IBallPresenter _ballPresenter;

        protected override GameStatesEnum GameState => GameStatesEnum.Playing;

        public PlayingGameState(IEventBus eventBus, IBallPresenter ballPresenter)
        {
            _eventBus = eventBus;
            _ballPresenter = ballPresenter;
        }

        protected override void OnEnterState()
        {
            Debug.Log("Entering Playing Game State");
            _eventBus.Publish(new ShotEvent(_ballPresenter, ShotResultEnum.BackboardBasket));
        }

        protected override void OnExitState()
        {
            Debug.Log("Exiting Playing Game State");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnFixedUpdate()
        {
        }
    }
}