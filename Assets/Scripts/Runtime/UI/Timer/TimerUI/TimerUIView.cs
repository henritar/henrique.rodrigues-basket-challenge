using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Runtime.UI.Timer.TimerUI
{
    public class TimerUIView : BaseUIView, ITimerUIView
    {
        [SerializeField] private TMP_Text timerValueText;
        public void SetTimerValue(float value)
        {
            timerValueText.text = $"{value:0.00}";
        }
    }
}