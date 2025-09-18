using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UniRx;

namespace Assets.Scripts.Runtime.UI.Timer.TimerMenu
{
    public class TimerMenuModel : BaseModel, ITimerMenuModel
    {
        private readonly ReactiveProperty<bool> _isUIVisible = new ReactiveProperty<bool>(false);
        public int TimerDuration { get; set; }
        public IReadOnlyReactiveProperty<bool> IsUIVisible => _isUIVisible;

        public void SetUIVisible(bool visible)
        {
            _isUIVisible.Value = visible;
        }
    }
}