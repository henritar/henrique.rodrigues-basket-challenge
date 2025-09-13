using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared.Interfaces.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers.States.MainGame
{
    public class RewardGameState : IGameState
    {
        public GameStatesEnum State => GameStatesEnum.Reward;

        private IStatesManager<GameStatesEnum> _stateManager;

        public RewardGameState(IStatesManager<GameStatesEnum> stateManager)
        {
            _stateManager = stateManager;
        }

        public void EnterState()
        {
            Debug.Log("Entering Reward Game State");
        }

        public void ExitState()
        {
            Debug.Log("Exiting Reward Game State");
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }
    }
}