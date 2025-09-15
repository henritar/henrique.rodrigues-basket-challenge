using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UniRx;

namespace Assets.Scripts.Runtime.UI.BackboardBonusUI
{
    public class BackboardBonusUIPresenter : BasePresenter<IBackboardBonusUIModel, IBackboardBonusUIView>, IBackboardBonusUIPresenter
    {

        private CompositeDisposable _disposables = new CompositeDisposable();

        public BackboardBonusUIPresenter(IBackboardBonusUIModel model, IBackboardBonusUIView view) : base(model, view)
        {
        }

        public void ShowUI(bool show, BonusTypeEnum bonus = BonusTypeEnum.None)
        {
            switch (show)
            {
                case true:
                    View.Show();
                    break;
                case false:
                    View.Hide();
                    break;
            }

            Model.SetUIVisible(show);
            Model.UpdateBonus(bonus);
        }

        protected override void SubscribeToEvents()
        {
            Model.CurrentBonus.Subscribe(UpdateBonus).AddTo(_disposables);
            Model.IsUIVisible.Subscribe(OnUIVisibleChanged).AddTo(_disposables);
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