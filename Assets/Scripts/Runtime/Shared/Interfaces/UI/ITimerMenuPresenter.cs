using Assets.Scripts.Runtime.Shared.Interfaces.MVP;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface ITimerMenuPresenter : IBasePresenter
    {
        void ShowUI(bool show);
    }
}