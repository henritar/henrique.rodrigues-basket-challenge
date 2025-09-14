using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Constants;
using Assets.Scripts.Runtime.Shared.EventBus.Events;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.InputSystem.Gameplay;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using Assets.Scripts.Runtime.UI.MainMenu;
using Cysharp.Threading.Tasks;
using System.Threading;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers.States.MainGame
{
    public class PlayingGameState : BaseGameState
    {
        private readonly IEventBus _eventBus;
        private readonly IBallPresenter _ballPresenter;
        private readonly IPlayingInputHandler _inputHandler;
        private readonly IGameplayInputManager _inputManager;
        private readonly IGameplayUIPresenter _gameplayUIPresenter;

        private Vector2 _startPosition;
        private Vector2 _currentPosition;
        private float _startTime;
        private bool _isTracking;
        private bool _hasCalculated;
        private CancellationTokenSource _swipeCts;


        private CompositeDisposable _disposables;

        protected override GameStatesEnum GameState => GameStatesEnum.Playing;

        public PlayingGameState(IEventBus eventBus, IBallPresenter ballPresenter, IPlayingInputHandler inputHandler,
            IGameplayInputManager inputManager, IGameplayUIPresenter gameplayUIPresenter)
        {
            _eventBus = eventBus;
            _ballPresenter = ballPresenter;
            _inputHandler = inputHandler;
            _inputManager = inputManager;
            _gameplayUIPresenter = gameplayUIPresenter;
        }

        protected override void OnEnterState()
        {
            Debug.Log("Entering Playing Game State");
            _gameplayUIPresenter.ShowUI(true);
            _inputManager.SetCurrentInputHandler(_inputHandler);
            _inputHandler.OnHoldClick += StartSwipeTracking;
            _inputHandler.OnReleaseClick += EndSwipeTracking;
            _disposables = new CompositeDisposable();
            _ballPresenter.OnBallReset.Subscribe(_ => ResetSwipeTracking()).AddTo(_disposables);
        }

        protected override void OnExitState()
        {
            _inputHandler.OnReleaseClick -= EndSwipeTracking;
            _inputHandler.OnHoldClick -= StartSwipeTracking;
            _inputManager.SetCurrentInputHandler(null);
            _disposables.Dispose();
            _disposables = null;
            _gameplayUIPresenter.ShowUI(false);
            Debug.Log("Exiting Playing Game State");
        }

        private void StartSwipeTracking()
        {
            if (_isTracking)
            {
                return;
            }

            _startPosition = _inputManager.PointerPosition;
            _currentPosition = _startPosition;
            _startTime = Time.time;
            _isTracking = true;

            _swipeCts?.Cancel();
            _swipeCts = new CancellationTokenSource();

            TrackSwipeAsync(_swipeCts.Token).Forget();
        }

        private async UniTask TrackSwipeAsync(CancellationToken ct)
        {
            Vector2 lastPosition = _startPosition;
            float lastMoveTime = _startTime;

            while (_isTracking && !ct.IsCancellationRequested)
            {
                await UniTask.NextFrame(ct);

                _currentPosition = _inputManager.PointerPosition;
                Vector2 deltaMove = _currentPosition - lastPosition;
                float currentTime = Time.time;
                float deltaTime = currentTime - lastMoveTime;

                float currentSpeed = deltaMove.magnitude / deltaTime;

                bool isMovingUp = deltaMove.y > 0;
                bool isMovingFastEnough = currentSpeed >= GameConstants.MinSwipeSpeed;
                bool withinTimeWindow = (currentTime - _startTime) <= GameConstants.SwipeTimeWindow;

                if (!withinTimeWindow || (!isMovingUp && deltaMove.magnitude > 5f) ||
                    (deltaTime > 0.1f && !isMovingFastEnough))
                {
                    CalculateAndReturnPower();
                    break;
                }

                lastPosition = _currentPosition;
                lastMoveTime = currentTime;
            }
        }

        private void EndSwipeTracking()
        {
            if (_isTracking && !_hasCalculated)
            {
                CalculateAndReturnPower();
            }
        }

        private void CalculateAndReturnPower()
        {
            _hasCalculated = true;
            _swipeCts?.Cancel();

            Vector2 totalDelta = _currentPosition - _startPosition;
            float upwardDistance = Mathf.Max(0, totalDelta.y);

            float power = Mathf.Clamp01(upwardDistance / GameConstants.MaxSwipeDistance) * 100f;

            ShotResultEnum shotResult = SelectShotResult(power);
            Debug.Log($"{shotResult.ToString()} with {power} power");
            _eventBus.Publish(new ShotEvent(_ballPresenter, shotResult));
        }

        private ShotResultEnum SelectShotResult(float power)
        {
            return power switch
            {
                >= 40f and <= 55f => ShotResultEnum.PerfectShot,
                >= 70f and <= 85f => ShotResultEnum.BackboardBasket,
                >= 30f and < 40f => ShotResultEnum.RingTouch,
                > 55f and < 70f => ShotResultEnum.RingTouch,
                < 30f => ShotResultEnum.MissWeak,
                > 85f => ShotResultEnum.MissStrong,
                _ => ShotResultEnum.MissWeak
            };
        }

        private void ResetSwipeTracking()
        {
            _isTracking = false;
            _hasCalculated = false;
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnFixedUpdate()
        {
        }
    }
}