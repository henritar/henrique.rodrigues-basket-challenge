using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UniRx;

namespace Assets.Scripts.Runtime.UI.RewardMenu
{
    public class RewardMenuModel : BaseModel, IRewardMenuModel
    {
        private readonly ReactiveProperty<bool> _isUIVisible = new ReactiveProperty<bool>(false);

        public IReadOnlyReactiveProperty<bool> IsUIVisible => _isUIVisible;

        public void SetUIVisible(bool visible)
        {
            _isUIVisible.Value = visible;
        }
    }
}