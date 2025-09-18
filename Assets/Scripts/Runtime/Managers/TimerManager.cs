using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers
{
    public class TimerManager : BaseManager, ITimerManager
    {
        private CompositeDisposable _disposables;
        private ReactiveProperty<float> _timer = new();
        private int _initialTime;
        private float _startedTime;
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

            Debug.Log($"TimerManager: Timer set to {_initialTime} seconds.");
        }

        public void StartTimer()
        {
            _startedTime = Time.time;
            _timer = new ReactiveProperty<float>(_initialTime);

            Observable.EveryUpdate()
                .TakeWhile(_ => _timer.Value > 0)
                .Subscribe(_ => TickTimer())
                .AddTo(_disposables);
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

        private void TickTimer()
        {
            float elapsed = Time.time - _startedTime;
            _timer.Value = Mathf.Max(0, _initialTime - elapsed);
        }
    }
}