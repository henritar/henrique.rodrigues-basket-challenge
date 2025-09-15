using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;

namespace Assets.Scripts.Runtime.Shared.Interfaces
{
    public interface IShootingPositionManager : IBaseManager
    {
        void MoveToRandomShootingPosition();
    }
}