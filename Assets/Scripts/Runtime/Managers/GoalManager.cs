using Assets.Scripts.Runtime.Enums;
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
        private ReactiveProperty<int> _currentScore = new();

        private BonusTypeEnum _currentBonus = BonusTypeEnum.None;
        private ShotResultEnum _shotResult = ShotResultEnum.MissWeak;

        public int CurrentScore => _currentScore.Value;

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
            _eventBus.OnEvent<ShotEvent>().Subscribe(OnShotMade).AddTo(_disposables);
            _eventBus.OnEvent<UpdateBonusEvent>().Subscribe(OnNewBonus).AddTo(_disposables);
            _eventBus.OnEvent<GameStartEvent>().Subscribe(_ => _currentScore.Value = 0).AddTo(_disposables);

            _currentScore.Subscribe(OnUpdateScore).AddTo(_disposables);

            _isInitialized = true;
        }

        private void OnGoalScored(GoalEvent goalEvent)
        {
            int points = 0;
            if (_currentBonus != BonusTypeEnum.None && _shotResult == ShotResultEnum.BackboardBasket)
            {
                points = (int)_currentBonus;
            }
            else
            {
                points = _shotResult switch
                {
                    ShotResultEnum.PerfectShot => 3,
                    ShotResultEnum.RingTouch or  ShotResultEnum.BackboardBasket => 2,
                    _ => 0
                };
            }

            _currentScore.Value += points;
            Debug.Log($"Goal scored! Points: {points}");
        }

        private void OnUpdateScore(int newScore)
        {
            _eventBus.Publish(new UpdateScoreEvent(newScore));
        }

        private void OnShotMade(ShotEvent shotEvent)
        {
            _shotResult = shotEvent.ShotResult;
        }

        private void OnNewBonus(UpdateBonusEvent updateBonusEvent)
        {
            _currentBonus = updateBonusEvent.Bonus;
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