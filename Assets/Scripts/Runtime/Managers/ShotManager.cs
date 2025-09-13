using Assets.Scripts.Runtime.Gameplay.Interactables;
using Assets.Scripts.Runtime.Shared;

namespace Assets.Scripts.Runtime.Managers
{
    public class ShotManager : BaseManager
    {
        private readonly Ball _ballPresenter;

        public override void Initialize()
        {
           _isInitialized = true;
        }
    }
}