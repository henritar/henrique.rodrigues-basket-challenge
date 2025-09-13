using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UnityEngine.Events;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface IMainMenuView : IBaseView
    {
        void SetStartButtonListener(UnityAction action);
        void SetQuitButtonListener(UnityAction action);
    }
}