using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Constants;
using Assets.Scripts.Runtime.Shared.EventBus.Events;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers
{
    public class ShotManager : BaseManager, IShotManager
    {
        private readonly IEventBus _eventBus;
        private readonly IBasketPoint _basketPoint;
        private readonly IBackboardPoint _backboardPoint;

        private CompositeDisposable _disposables;

        public ShotManager(IEventBus eventBus, IBasketPoint basketPoint, IBackboardPoint backboardPoint)
        {
            _eventBus = eventBus;
            _basketPoint = basketPoint;
            _backboardPoint = backboardPoint;
        }

        public override void Initialize()
        {
            if (_isInitialized)
            {
                Debug.LogWarning("ShotManager is already initialized. Skipping initialization.");
                return;
            }

            _disposables = new();

            _eventBus.OnEvent<ShotEvent>().Subscribe(OnExecuteShot)
                .AddTo(_disposables);

            _isInitialized = true;
        }

        public void OnExecuteShot(ShotEvent shotEvent)
        {
            var ballPresenter = shotEvent.BallPresenter;

            Vector3 velocity = CalculateVelocity(ballPresenter.BallPosition, shotEvent.ShotResult);

            ballPresenter.SetBallVelocity(velocity);
        }

        public Vector3 CalculateVelocity(Vector3 startPos, ShotResultEnum targetResult)
        {
            Vector3 targetPos = GetTargetPosition(startPos, targetResult);
            return CalculateTrajectoryVelocity(startPos, targetPos);
        }

        private Vector3 GetTargetPosition(Vector3 startPos, ShotResultEnum result)
        {
            Vector3 displacement = _basketPoint.Position - startPos;
            Vector3 shotDirection = displacement.normalized;

            switch (result)
            {
                case ShotResultEnum.PerfectShot:
                    return _basketPoint.Position;

                case ShotResultEnum.BackboardBasket:
                    return _backboardPoint.Position;

                case ShotResultEnum.RingTouch:
                    Vector3 lateral = Vector3.Cross(Vector3.up, shotDirection).normalized;

                    float backFactor = Mathf.Clamp01(Mathf.Abs(displacement.z) / GameConstants.BackClampFactor);

                    Vector3 mixDir = Vector3.Lerp(shotDirection, lateral * GameConstants.GetRandomEvenOdd(), backFactor).normalized;

                    Vector3 rimOffset = mixDir * GameConstants.BasketRadius;
                    return _basketPoint.Position + rimOffset;
                case ShotResultEnum.MissWeak:
                        return _basketPoint.Position - shotDirection * GameConstants.MissWeakDistance;
                case ShotResultEnum.MissStrong:
                        return _basketPoint.Position + shotDirection * GameConstants.MissStrongDistance;
                default:
                    return _backboardPoint.Position + Random.insideUnitSphere;
            }
        }

        private Vector3 CalculateTrajectoryVelocity(Vector3 start, Vector3 target)
        {
            Vector3 displacement = target - start;
            Vector3 displacementXZ = new Vector3(displacement.x, 0, displacement.z);

            float horizontalDistance = displacementXZ.magnitude;
            float timeToTarget = Mathf.Clamp(horizontalDistance / GameConstants.TimeClampFactor, GameConstants.MinShotTimeToTarget, GameConstants.MaxShotTimeToTarget);

            Vector3 velocityXZ = displacementXZ / timeToTarget;
            float velocityY = (displacement.y - 0.5f * Physics.gravity.y * timeToTarget * timeToTarget) / timeToTarget;

            return velocityXZ + Vector3.up * velocityY;
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