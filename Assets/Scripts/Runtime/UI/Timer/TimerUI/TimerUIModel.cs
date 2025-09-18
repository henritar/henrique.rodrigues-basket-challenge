using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UniRx;

namespace Assets.Scripts.Runtime.UI.Timer.TimerUI
{
    public class TimerUIModel : BaseModel, ITimerUIModel
    {
        private readonly ReactiveProperty<bool> _isUIVisible = new ReactiveProperty<bool>(false);
        private readonly ReactiveProperty<float> _currentTimerValue = new ReactiveProperty<float>();
        public IReadOnlyReactiveProperty<bool> IsUIVisible => _isUIVisible;

        public IReadOnlyReactiveProperty<float> CurrentTimerValue => _currentTimerValue;

        public void SetUIVisible(bool visible)
        {
            _isUIVisible.Value = visible;
        }
        public void SetTimerValue(float value)
        {
            _currentTimerValue.Value = value;
        }
    }
}