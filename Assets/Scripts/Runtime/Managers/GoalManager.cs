using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.EventBus.Events;
using Assets.Scripts.Runtime.Shared.Interfaces;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers
{
    public class GoalManager : BaseManager, IGoalManager
    {
        private readonly IEventBus _eventBus;

        private CompositeDisposable _disposables;
        public GoalManager(IEventBus eventBus) 
        {
            _eventBus = eventBus;
        }

        public override void Initialize()
        {
            if (_isInitialized)
            {
                Debug.LogWarning("GoalManager is already initialized. Skipping initialization.");
                return;
            }

            _disposables = new();

            _eventBus.OnEvent<GoalEvent>().Subscribe(OnGoalScored)
                .AddTo(_disposables);

            _isInitialized = true;
        }

        private void OnGoalScored(GoalEvent goalEvent)
        {
            Debug.Log($"Goal scored! Points: {goalEvent.Points}");
        }

        protected override void OnDestroying()
        {
            if (!_isInitialized)
            {
                return;
            }

            _disposables?.Dispose();
            _disposables = null;
            _isInitialized = false;
        }
    }
}