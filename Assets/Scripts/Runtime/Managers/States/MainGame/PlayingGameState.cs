using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.InputSystem.Gameplay;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers.States.MainGame
{
    public class PlayingGameState : BaseGameState
    {
        private readonly IBallPresenter _ballPresenter;
        private readonly IPlayingInputHandler _inputHandler;
        private readonly IGameplayInputManager _inputManager;
        private readonly IGameplayUIPresenter _gameplayUIPresenter;
        private readonly ISwipeManager _swipeManager;


        private CompositeDisposable _disposables;

        protected override GameStatesEnum GameState => GameStatesEnum.Playing;

        public PlayingGameState(IBallPresenter ballPresenter, IPlayingInputHandler inputHandler,
            IGameplayInputManager inputManager, IGameplayUIPresenter gameplayUIPresenter, ISwipeManager swipeManager)
        {
            _ballPresenter = ballPresenter;
            _inputHandler = inputHandler;
            _inputManager = inputManager;
            _gameplayUIPresenter = gameplayUIPresenter;
            _swipeManager = swipeManager;
            
            _inputHandler.BallPresenter = _ballPresenter;
        }

        protected override void OnEnterState()
        {
            Debug.Log("Entering Playing Game State");
            _gameplayUIPresenter.ShowUI(true);
            _inputManager.SetCurrentInputHandler(_inputHandler);
            _inputHandler.OnHoldClick += _swipeManager.StartSwipeTracking;
            _inputHandler.OnReleaseClick += _swipeManager.EndSwipeTracking;
            _disposables = new CompositeDisposable();
            _ballPresenter.OnBallReset.Subscribe(_ => _swipeManager.ResetSwipeTracking()).AddTo(_disposables);
        }

        protected override void OnExitState()
        {
            _inputHandler.OnReleaseClick -= _swipeManager.EndSwipeTracking;
            _inputHandler.OnHoldClick -= _swipeManager.StartSwipeTracking;
            _inputManager.SetCurrentInputHandler(null);
            _disposables.Dispose();
            _disposables = null;
            _gameplayUIPresenter.ShowUI(false);
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