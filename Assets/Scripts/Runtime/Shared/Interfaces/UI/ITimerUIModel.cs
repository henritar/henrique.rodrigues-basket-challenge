using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UniRx;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface ITimerUIModel : IBaseModel
    {
        IReadOnlyReactiveProperty<float> CurrentTimerValue { get; }
        IReadOnlyReactiveProperty<bool> IsUIVisible { get; }
        void SetUIVisible(bool visible);
        void SetTimerValue(float value);
    }
}