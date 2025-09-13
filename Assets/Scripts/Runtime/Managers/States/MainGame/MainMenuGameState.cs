using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared.Interfaces.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers.States.MainGame
{
    public class MainMenuGameState : IGameState
    {
        public GameStatesEnum State => GameStatesEnum.MainMenu;

        private IStatesManager<GameStatesEnum> _stateManager;

        public MainMenuGameState(IStatesManager<GameStatesEnum> stateManager)
        {
            _stateManager = stateManager;
        }

        public void EnterState()
        {
            Debug.Log("Entering MainMenu Game State");
        }

        public void ExitState()
        {
            Debug.Log("Exiting MainMenu Game State");
        }

        public void Update()
        {
        }
        
        public void FixedUpdate()
        {
        }
    }
}
