using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Constants;
using Assets.Scripts.Runtime.Shared.EventBus.Events;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers
{
    public class BackboardBonusManager : BaseManager, IBackboardBonusManager
    {
        private readonly IBackboardBonusUIPresenter _backboardBonusUIPresenter;
        private readonly IEventBus _eventBus;

        private float _noBonusChance = GameConstants.NoBonusChance;
        private float _commonChance = GameConstants.CommonBonusChance;
        private float _rareChance = GameConstants.RareBonusChance;
        private float _veryRareChance = GameConstants.VeryRareBonusChance;

        private bool isGenerating;

        private CancellationTokenSource cancellationTokenSource;
        private CompositeDisposable _disposables;
        public BackboardBonusManager(IBackboardBonusUIPresenter backboardBonusUIPresenter, IEventBus eventBus)
        {
            _backboardBonusUIPresenter = backboardBonusUIPresenter;
            _eventBus = eventBus;
        }

        public override void Initialize()
        {
            if (_isInitialized)
            {
                Debug.LogWarning("SwipeManager is already initialized. Skipping initialization.");
                return;
            }

            NormalizeProbabilities();
            _backboardBonusUIPresenter.ShowUI(false);
            _disposables = new();

            _isInitialized = true;
        }

        public void StartBonusGeneration()
        {
            if (isGenerating) 
            { 
                return;
            }

            isGenerating = true;
            cancellationTokenSource = new CancellationTokenSource();

            BonusGenerationLoopAsync(cancellationTokenSource.Token).Forget();
        }

        public void StopBonusGeneration()
        {
            isGenerating = false;
            cancellationTokenSource?.Cancel();
            cancellationTokenSource?.Dispose();
            cancellationTokenSource = null;
        }

        private async UniTaskVoid BonusGenerationLoopAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await SpawnBonusAsync(cancellationToken);
            }
        }

        private async UniTask SpawnBonusAsync(CancellationToken cancellationToken)
        {
            var bonusType = RollBonusType();
            
            _eventBus.Publish(new UpdateBonusEvent(bonusType));
            var showUI = bonusType != BonusTypeEnum.None;
            _backboardBonusUIPresenter.ShowUI(true, bonusType);

            float waitTime = UnityEngine.Random.Range(GameConstants.MinBonusInterval, GameConstants.MaxBonusInterval);
            await UniTask.Delay(TimeSpan.FromSeconds(waitTime), cancellationToken: cancellationToken);

            _backboardBonusUIPresenter.ShowUI(false);
        }

        private BonusTypeEnum RollBonusType()
        {
            float roll = UnityEngine.Random.Range(0f, 1f);

            if (roll <= _noBonusChance)
            {
                return BonusTypeEnum.None;
            }
            else if (roll <= _commonChance + _noBonusChance)
            {
                return BonusTypeEnum.FourPoints;
            }
            else if (roll <= _commonChance + _rareChance)
            {
                return BonusTypeEnum.SixPoints;
            }
            else
                return BonusTypeEnum.EightPoints;
        }

        private void NormalizeProbabilities()
        {
            float total = GameConstants.NoBonusChance + GameConstants.CommonBonusChance + GameConstants.RareBonusChance + GameConstants.VeryRareBonusChance;
            _noBonusChance /= total;
            _commonChance /= total;
            _rareChance /= total;
            _veryRareChance /= total;
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