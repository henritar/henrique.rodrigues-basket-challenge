using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.EventBus.Events;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UniRx;

namespace Assets.Scripts.Runtime.UI.BackboardBonusUI
{
    public class BackboardBonusUIPresenter : BasePresenter<IBackboardBonusUIModel, IBackboardBonusUIView>, IBackboardBonusUIPresenter
    {
        private IEventBus _eventBus;
        private CompositeDisposable _disposables = new CompositeDisposable();

        public BackboardBonusUIPresenter(IBackboardBonusUIModel model, IBackboardBonusUIView view, IEventBus eventBus) : base(model, view)
        {
            _eventBus = eventBus;
        }

        public void ShowUI(bool show)
        {
            Model.SetUIVisible(show);
        }

        protected override void SubscribeToEvents()
        {
            Model.CurrentBonus.Subscribe(UpdateBonus).AddTo(_disposables);
            Model.IsUIVisible.Subscribe(OnUIVisibleChanged).AddTo(_disposables);
            _eventBus.OnEvent<UpdateBonusEvent>().Subscribe(OnBonusUpdated).AddTo(_disposables);
        }


        protected override void UnsubscribeFromEvents()
        {
        }

        private void OnUIVisibleChanged(bool visible)
        {
            switch (visible)
            {
                case true:
                    View.Show();
                    break;
                case false:
                    View.Hide();
                    break;
            }
        }

        private void OnBonusUpdated(UpdateBonusEvent bonusEvent)
        {
            bool showUI = bonusEvent.Bonus != BonusTypeEnum.None;
            ShowUI(showUI);
            UpdateBonus(bonusEvent.Bonus);
        }

        private void UpdateBonus(BonusTypeEnum bonus)
        {
            View.EnableBonus(bonus);
        }
        protected override void Cleanup()
        {
            _disposables.Dispose();
            _disposables = null;
        }
    }
}