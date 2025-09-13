using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers.States.MainGame
{
    public class RewardGameState : BaseGameState
    {
        protected override GameStatesEnum GameState => GameStatesEnum.Reward;

        protected override void OnEnterState()
        {
            Debug.Log("Entering Reward Game State");
        }

        protected override void OnExitState()
        {
            Debug.Log("Exiting Reward Game State");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnFixedUpdate()
        {
        }
    }
}