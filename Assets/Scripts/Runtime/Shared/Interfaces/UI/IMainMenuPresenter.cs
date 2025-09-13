using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UnityEngine.Events;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface IMainMenuPresenter : IBasePresenter
    {
        void SetStartGameAction(UnityAction action);
        void ShowUI(bool show);
    }
}