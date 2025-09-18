using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UniRx;

namespace Assets.Scripts.Runtime.UI.Timer.TimerUI
{
    public class TimerUIPresenter : BasePresenter<ITimerUIModel, ITimerUIView>, ITimerUIPresenter
    {
        private CompositeDisposable _disposables = new CompositeDisposable();

        public TimerUIPresenter(ITimerUIModel model, ITimerUIView view) : base(model, view)
        {
        }

        public void ShowUI(bool show)
        {
            Model.SetUIVisible(show);
        }

        public void SetTimerValue(float value)
        {
            Model.SetTimerValue(value);
        }

        protected override void SubscribeToEvents()
        {
            Model.IsUIVisible.Subscribe(OnUIVisibleChanged).AddTo(_disposables);
            Model.CurrentTimerValue.Subscribe(View.SetTimerValue).AddTo(_disposables);
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
    }
}