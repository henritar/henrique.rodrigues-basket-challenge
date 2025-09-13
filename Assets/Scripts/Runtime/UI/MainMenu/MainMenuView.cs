using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.UI.MainMenu
{
    public class MainMenuView : BaseUIView, IMainMenuView
    {
        [SerializeField] private Button _startBtn;
        [SerializeField] private Button _quitBtn;

        public void SetStartButtonListener(UnityAction action)
        {
            _startBtn.onClick.AddListener(action);
        }

        public void SetQuitButtonListener(UnityAction action)
        {
            _quitBtn.onClick.AddListener(action);
        }
    }
}