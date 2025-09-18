using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers
{
    public class TimerManager : BaseManager, ITimerManager
    {
        private CompositeDisposable _disposables;
        private ReactiveProperty<float> _timer;
        private int _initialTime;
        public IReadOnlyReactiveProperty<float> Timer => _timer;
        public override void Initialize()
        {
            if (_isInitialized)
            {
                Debug.LogWarning("TimeManager is already initialized. Skipping initialization.");
                return;
            }

            _disposables = new();

            _isInitialized = true;
        }

        public void SetInitialTimer(int time)
        {
            _initialTime = time;
            _timer = new ReactiveProperty<float>(time);

            Debug.Log($"TimerManager: Timer set to {_initialTime} seconds.");
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