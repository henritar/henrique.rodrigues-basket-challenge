using Assets.Scripts.Runtime.Shared.Interfaces.MVP;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface ITimerUIPresenter : IBasePresenter
    {
        void ShowUI(bool show);
        void SetTimerValue(float value);
    }
}