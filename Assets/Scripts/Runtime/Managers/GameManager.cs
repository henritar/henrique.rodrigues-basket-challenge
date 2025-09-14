using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers
{
    public class GameManager : BaseManager, IGameManager
    {
        private IGameStateManager _gameStatesManager;

        public GameManager(IGameStateManager gameStateManager)
        {
            _gameStatesManager = gameStateManager;
        }

        public override void Initialize()
        {
            if (_isInitialized)
            {
                Debug.LogWarning("GameManager is already initialized. Skipping initialization.");
                return;
            }

            Debug.Log("GameManager initialized.");

            InitializeGame();
            _isInitialized = true;
        }

        private void InitializeGame()
        {
            Debug.Log("Initializing game...");
            _gameStatesManager.ChangeState(GameStatesEnum.Playing);
        }

        protected override void OnUpdate()
        {
            _gameStatesManager.Update();
        }

        protected override void OnFixedUpdate()
        {
            _gameStatesManager.FixedUpdate();
        }
    }
}