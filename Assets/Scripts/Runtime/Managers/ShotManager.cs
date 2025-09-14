using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.EventBus.Events;
using Assets.Scripts.Runtime.Shared.Interfaces;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers
{
    public class ShotManager : BaseManager, IShotManager
    {
        private readonly IEventBus _eventBus;

        private CompositeDisposable _disposables;

        public ShotManager(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public override void Initialize()
        {
            if (_isInitialized)
            {
                Debug.LogWarning("ShotManager is already initialized. Skipping initialization.");
                return;
            }

            _disposables = new();

            _eventBus.OnEvent<ShotEvent>().Subscribe(OnExecuteShot)
                .AddTo(_disposables);

            _isInitialized = true;
        }

        public void OnExecuteShot(IGameEvent shotEvent)
        {
        }
    }
}