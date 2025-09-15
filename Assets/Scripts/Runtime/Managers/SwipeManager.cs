using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Constants;
using Assets.Scripts.Runtime.Shared.EventBus.Events;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using Cysharp.Threading.Tasks;
using System.Threading;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers
{
    public class SwipeManager : BaseManager, ISwipeManager
    {
        private readonly IGameplayInputManager _inputManager;
        private readonly IEventBus _eventBus;
        private readonly IShootingPositionManager _shootingPositionManager;

        private IBallPresenter _ballPresenter;
        private CompositeDisposable _disposables;

        private Vector2 _startPosition;
        private Vector2 _currentPosition;
        private float _startTime;
        private bool _isTracking;
        private bool _hasCalculated;
        private CancellationTokenSource _swipeCts;

        public SwipeManager(IGameplayInputManager inputManager, IEventBus eventBus, IShootingPositionManager shootingPositionManager)
        {
            _inputManager = inputManager;
            _eventBus = eventBus;
            _shootingPositionManager = shootingPositionManager;
        }

        public override void Initialize()
        {
            if (_isInitialized)
            {
                Debug.LogWarning("SwipeManager is already initialized. Skipping initialization.");
                return;
            }

            _disposables = new();

            _isInitialized = true;
        }

        public void StartSwipeTracking(IBallPresenter ballPresenter)
        {
            if (_isTracking)
            {
                return;
            }

            _ballPresenter = ballPresenter;
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

        public void EndSwipeTracking()
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

        public void ResetSwipeTracking()
        {
            _shootingPositionManager.MoveToRandomShootingPosition();
            _isTracking = false;
            _hasCalculated = false;
        }

        protected override void OnDestroying()
        {
            if (!_isInitialized)
            {
                return;
            }

            _disposables?.Dispose();
            _disposables = null;
            _isInitialized = false;
        }
    }
}