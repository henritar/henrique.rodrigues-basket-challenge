using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;

namespace Assets.Scripts.Runtime.UI.BackboardBonusUI
{
    public class BackboardBonusUIPresenter : BasePresenter<IBackboardBonusUIModel, IBackboardBonusUIView>, IBackboardBonusUIPresenter
    {
        public BackboardBonusUIPresenter(IBackboardBonusUIModel model, IBackboardBonusUIView view) : base(model, view)
        {
        }

        protected override void SubscribeToEvents()
        {
        }

        protected override void UnsubscribeFromEvents()
        {
        }
    }
}