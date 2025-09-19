using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;

namespace Assets.Scripts.Runtime.Shared.Interfaces
{
    public interface ISwipeManager : IBaseManager
    {
        void StartSwipeTracking(IBallPresenter ballPresenter);
        void EndSwipeTracking();
        void ResetSwipeTracking();
        void ShowInputBar(bool show);
    }
}