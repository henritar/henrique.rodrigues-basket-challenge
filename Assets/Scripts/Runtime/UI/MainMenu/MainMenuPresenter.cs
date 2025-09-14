using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#else
using UnityEngine;
#endif

namespace Assets.Scripts.Runtime.UI.MainMenu
{
    public class MainMenuPresenter : BasePresenter<IMainMenuModel, IMainMenuView>, IMainMenuPresenter
    {
        public MainMenuPresenter(IMainMenuModel model, IMainMenuView view) : base(model, view)
        {
        }

        public void ShowUI(bool show)
        {
            switch (show)
            {
                case true:
                    View.Show();
                    break;
                case false:
                    View.Hide();
                    break;
            }

            Model.SetUIVisible(show);
        }

        public void SetStartGameAction(UnityAction action)
        {
            View.SetStartButtonListener(action);
        }

        protected override void OnInitialize()
        {
        }

        protected override void SubscribeToEvents()
        {
            SetQuitGameAction();
        }

        protected override void UnsubscribeFromEvents()
        {
        }

        private void SetQuitGameAction()
        {
            View.SetQuitButtonListener(QuitGame);
        }

        private void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}