using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.EventBus.Events;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UniRx;

namespace Assets.Scripts.Runtime.UI.GameplayUI
{
    public class GameplayUIPresenter : BasePresenter<IGameplayUIModel, IGameplayUIView>, IGameplayUIPresenter
    {
        private readonly IEventBus _eventBus;
        private CompositeDisposable _disposables = new CompositeDisposable();

        public GameplayUIPresenter(IGameplayUIModel model, IGameplayUIView view, IEventBus eventBus) : base(model, view)
        {
            _eventBus = eventBus;
        }

        public void ShowUI(bool show)
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
        }

        protected override void OnInitialize()
        {
            _disposables = new CompositeDisposable();
            
        }

        protected override void SubscribeToEvents()
        {
            _eventBus.OnEvent<GoalEvent>()
                .Subscribe(OnGoalScored)
                .AddTo(_disposables);

            Model.CurrentPoints
                .Subscribe(points => View.UpdateScore(points))
                .AddTo(_disposables);
        }

        protected override void UnsubscribeFromEvents()
        {
        }

        private void OnGoalScored(GoalEvent goalEvent)
        {
            Model.UpdatePoints(goalEvent.Points);
        }

        protected override void Cleanup()
        {
            _disposables.Dispose();
            _disposables = null;
        }
    }
}