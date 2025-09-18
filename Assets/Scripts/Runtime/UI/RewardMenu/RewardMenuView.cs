using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Runtime.UI.RewardMenu
{
    public class RewardMenuView : BaseUIView, IRewardMenuView
    {
        [SerializeField] private TextMeshProUGUI _finalScoreText;
        [SerializeField] private Button _playAgainBtn;
        [SerializeField] private Button _mainMenuBtn;

        public void SetFinalScore(int finalScore)
        {
            _finalScoreText.text = finalScore.ToString();
        }

        public void SetPlayAgainAction(UnityAction action)
        {
            _playAgainBtn.onClick.AddListener(action);
        }

        public void SetMainMenuAction(UnityAction action)
        {
            _mainMenuBtn.onClick.AddListener(action);
        }
    }
}