using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared.Interfaces.StateMachine;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers.States.MainGame
{
    public class MainMenuGameState : IGameState
    {
        public GameStatesEnum State => GameStatesEnum.MainMenu;

        private readonly IStatesManager<GameStatesEnum> _stateManager;
        private readonly IMainMenuPresenter _mainMenuPresenter;

        public MainMenuGameState(IMainMenuPresenter mainMenuPresenter)
        {
            _mainMenuPresenter = mainMenuPresenter;
        }

        public void EnterState()
        {
            Debug.Log("Entering MainMenu Game State");
            _mainMenuPresenter.ShowUI(true);
        }

        public void ExitState()
        {
            Debug.Log("Exiting MainMenu Game State");
            _mainMenuPresenter.ShowUI(false);
        }

        public void Update()
        {
        }
        
        public void FixedUpdate()
        {
        }
    }
}
