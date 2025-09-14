using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;

namespace Assets.Scripts.Runtime.UI.GameplayUI
{
    public class GameplayUIPresenter : BasePresenter<IGameplayUIModel, IGameplayUIView>, IGameplayUIPresenter
    {
        public GameplayUIPresenter(IGameplayUIModel model, IGameplayUIView view) : base(model, view)
        {
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

            Model.IsUIVisible = show;
        }

        protected override void SubscribeToEvents()
        {
            throw new System.NotImplementedException();
        }

        protected override void UnsubscribeFromEvents()
        {
            throw new System.NotImplementedException();
        }
    }
}