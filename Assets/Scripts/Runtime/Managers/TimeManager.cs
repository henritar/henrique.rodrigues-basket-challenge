using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers
{
    public class TimeManager : BaseManager, ITimeManager
    {
        private CompositeDisposable _disposables;
        private ReactiveProperty<float> _timer;

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