using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.Data;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using UnityEngine;
using VContainer.Unity;

namespace Assets.Scripts.Runtime.Managers
{
    public class ShootingPositionManager : BaseManager, IShootingPositionManager, IPostInitializable
    {

        private readonly IPlayerPresenter _playerController;
        private readonly IShootingPositionData _shootingData;

        public ShootingPositionManager(IShootingPositionData shootingData, IPlayerPresenter playerController)
        {
            _shootingData = shootingData;
            _playerController = playerController;
        }

        public override void Initialize()
        {
            if (_isInitialized)
            {
                Debug.LogWarning("ShootingPositionManager is already initialized. Skipping initialization.");
                return;
            }

            _isInitialized = true;
        }

        public void MoveToRandomShootingPosition()
        {
            if (_shootingData.ShootingPositions == null || _shootingData.ShootingPositions.Length == 0)
            {
                Debug.LogWarning("ShootingPositionManager: No shooting positions available.");
                return;
            }
            int randomIndex = Random.Range(0, _shootingData.ShootingPositions.Length);
            _playerController.MoveToPosition(_shootingData.ShootingPositions[randomIndex]);
        }

        public void PostInitialize()
        {
            MoveToRandomShootingPosition();
        }
    }
}