using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers.States.MainGame
{
    public class PlayingGameState : BaseGameState
    {
        protected override GameStatesEnum GameState => GameStatesEnum.Playing;

        protected override void OnEnterState()
        {
            Debug.Log("Entering Playing Game State");
            _stateManager.ChangeState(GameStatesEnum.Reward);
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