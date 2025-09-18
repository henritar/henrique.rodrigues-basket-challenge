using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.EventBus.Events;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.Data;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Assets.Scripts.Runtime.Managers
{
    public class ShootingPositionManager : BaseManager, IShootingPositionManager
    {

        private readonly IPlayerPresenter _playerController;
        private readonly IShootingPositionData _shootingData;
        private readonly IEventBus _eventBus;

        private CompositeDisposable _disposables;

        public ShootingPositionManager(IShootingPositionData shootingData, IPlayerPresenter playerController, IEventBus eventBus)
        {
            _shootingData = shootingData;
            _playerController = playerController;
            _eventBus = eventBus;
        }

        public override void Initialize()
        {
            if (_isInitialized)
            {
                Debug.LogWarning("ShootingPositionManager is already initialized. Skipping initialization.");
                return;
            }

            _disposables = new();

            _eventBus.OnEvent<GoalEvent>().Subscribe(_ => DelayedMoveToPosition()).AddTo(_disposables);

            _isInitialized = true;
        }

        public void MoveToRandomShootingPosition()
        {
            if (_shootingData.ShootingPositions == null || _shootingData.ShootingPositions.Length == 0)
            {
                Debug.LogWarning("ShootingPositionManager: No shooting positions available.");
                return;
            }
            int randomIndex = UnityEngine.Random.Range(0, _shootingData.ShootingPositions.Length);
            _playerController.GetBall().ResetBall();
            _playerController.MoveToPosition(_shootingData.ShootingPositions[randomIndex]);
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

        private void DelayedMoveToPosition()
        {
            UniTask.Delay(TimeSpan.FromSeconds(0.15f)).ContinueWith(() =>
            {
                MoveToRandomShootingPosition();
            }).Forget();
        }
    }
}