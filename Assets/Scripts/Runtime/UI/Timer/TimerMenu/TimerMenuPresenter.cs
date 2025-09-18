using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.Data;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UniRx;

namespace Assets.Scripts.Runtime.UI.Timer.TimerMenu
{
    public class TimerMenuPresenter : BasePresenter<ITimerMenuModel, ITimerMenuView>, ITimerMenuPresenter
    {
        private readonly ITimerManager _timerManager;
        private readonly ITimerData _timerData;
        private CompositeDisposable _disposables = new CompositeDisposable();

        public TimerMenuPresenter(ITimerMenuModel model, ITimerMenuView view, ITimerManager timerManager, ITimerData timerData) : base(model, view)
        {
            _timerManager = timerManager;
            _timerData = timerData;
        }

        public void ShowUI(bool show)
        {
            Model.SetUIVisible(show);
        }

        protected override void SubscribeToEvents()
        {
            Model.IsUIVisible.Subscribe(OnUIVisibleChanged).AddTo(_disposables);
            View.OnTimerValueChanged.Subscribe(OnTimerValueChanged).AddTo(_disposables);

            View.SetTimerValues(_timerData.InitialTimerValues);
        }

        protected override void UnsubscribeFromEvents()
        {
        }

        protected override void Cleanup()
        {
            _disposables.Dispose();
            _disposables = null;
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

        private void OnTimerValueChanged(int value)
        {
            Model.TimerDuration = value;
            _timerManager.SetInitialTimer(value);
        }
    }
}