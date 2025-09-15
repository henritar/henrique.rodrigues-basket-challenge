using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Runtime.UI.GameplayUI
{
    public class GameplayUIView : BaseUIView, IGameplayUIView
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        public void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}