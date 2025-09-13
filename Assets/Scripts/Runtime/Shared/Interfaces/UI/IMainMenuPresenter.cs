using Assets.Scripts.Runtime.Shared.Interfaces.MVP;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface IMainMenuPresenter : IBasePresenter
    {
        void ShowUI(bool show);
    }
}