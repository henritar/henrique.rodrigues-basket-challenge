using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UnityEngine.Events;

namespace Assets.Scripts.Runtime.UI.RewardMenu
{
    public class RewardMenuPresenter : BasePresenter<IRewardMenuModel, IRewardMenuView>, IRewardMenuPresenter
    {
        public RewardMenuPresenter(IRewardMenuModel model, IRewardMenuView view) : base(model, view)
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

            Model.SetUIVisible(show);
        }

        public void SetMainMenuAction(UnityAction action)
        {
            View.SetMainMenuAction(action);
        }

        public void SetPlayAgainAction(UnityAction action)
        {
            View.SetPlayAgainAction(action);
        }

        protected override void SubscribeToEvents()
        {
        }

        protected override void UnsubscribeFromEvents()
        {
        }
    }
}