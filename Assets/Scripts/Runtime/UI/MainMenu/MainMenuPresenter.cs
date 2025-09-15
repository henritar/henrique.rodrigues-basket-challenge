using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UnityEngine.Events;
using UniRx;


#if UNITY_EDITOR
using UnityEditor;
#else
using UnityEngine;
#endif

namespace Assets.Scripts.Runtime.UI.MainMenu
{
    public class MainMenuPresenter : BasePresenter<IMainMenuModel, IMainMenuView>, IMainMenuPresenter
    {

        private CompositeDisposable _disposables = new CompositeDisposable();
        public MainMenuPresenter(IMainMenuModel model, IMainMenuView view) : base(model, view)
        {
        }

        public void ShowUI(bool show)
        {
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
            Model.IsUIVisible.Subscribe(OnUIVisibleChanged).AddTo(_disposables);
        }

        protected override void UnsubscribeFromEvents()
        {
        }

        private void SetQuitGameAction()
        {
            View.SetQuitButtonListener(QuitGame);
        }
        private void OnUIVisibleChanged(bool visible)
        {
            switch (visible)
            {
                case true:
                    View.Show();
                    break;
                case false:
                    View.Hide();
                    break;
            }
        }

        protected override void Cleanup()
        {
            _disposables.Dispose();
            _disposables = null;
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