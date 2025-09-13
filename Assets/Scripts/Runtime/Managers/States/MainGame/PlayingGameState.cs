using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared.Interfaces.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers.States.MainGame
{
    public class PlayingGameState : IGameState
    {
        public GameStatesEnum State => GameStatesEnum.Playing;

        private IStatesManager<GameStatesEnum> _stateManager;

        public PlayingGameState()
        {
        }

        public void EnterState()
        {
            Debug.Log("Entering Playing Game State");
        }

        public void ExitState()
        {
            Debug.Log("Exiting Playing Game State");
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }
        
    }
}