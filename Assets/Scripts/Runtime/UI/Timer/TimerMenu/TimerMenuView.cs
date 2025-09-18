using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using System;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.UI.Timer.TimerMenu
{
    public class TimerMenuView : BaseUIView, ITimerMenuView
    {
        [SerializeField] private TMP_Dropdown _timerDropdown;

        private List<int> _timerValues = new List<int>();
        private Subject<int> _onTimerValueChanged = new Subject<int>();

        public IObservable<int> OnTimerValueChanged => _onTimerValueChanged;

        private void Start()
        {
            _timerDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        }


        public void SetTimerValues(int[] values)
        {
            _timerValues.Clear();
            _timerValues.AddRange(values);

            _timerDropdown.ClearOptions();

            var options = new List<string>();
            foreach (var v in values)
            {
                options.Add(v.ToString());
            }

            _timerDropdown.AddOptions(options);
            _timerDropdown.value = 0;
            OnDropdownValueChanged(_timerDropdown.value);
        }

        private void OnDropdownValueChanged(int index)
        {
            if (index >= 0 && index < _timerValues.Count)
            {
                int selectedValue = _timerValues[index];
                _onTimerValueChanged.OnNext(selectedValue);
            }
        }
    }
}