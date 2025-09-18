using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UniRx;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface ITimerMenuModel : IBaseModel
    {
        int TimerDuration { get; set; }
        IReadOnlyReactiveProperty<bool> IsUIVisible { get; }
        void SetUIVisible(bool visible);

    }
}