using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers.States.MainGame
{
    public class MainMenuGameState : BaseGameState
    {
        protected override GameStatesEnum GameState => GameStatesEnum.MainMenu;

        private readonly IMainMenuPresenter _mainMenuPresenter;

        public MainMenuGameState(IMainMenuPresenter mainMenuPresenter)
        {
            _mainMenuPresenter = mainMenuPresenter;
        }

        protected override void OnEnterState()
        {
            Debug.Log("Entering MainMenu Game State");
            _mainMenuPresenter.ShowUI(true);
        }

        protected override void OnExitState()
        {
            Debug.Log("Exiting MainMenu Game State");
            _mainMenuPresenter.ShowUI(false);
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnFixedUpdate()
        {
        }
    }
}
