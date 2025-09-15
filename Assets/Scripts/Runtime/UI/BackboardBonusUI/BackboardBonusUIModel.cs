using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UniRx;

namespace Assets.Scripts.Runtime.UI.BackboardBonusUI
{
    public class BackboardBonusUIModel : BaseModel, IBackboardBonusUIModel
    {
        private readonly ReactiveProperty<bool> _isUIVisible = new ReactiveProperty<bool>(false);

        private readonly ReactiveProperty<BonusTypeEnum> _currentBonus = new ReactiveProperty<BonusTypeEnum>();

        public IReadOnlyReactiveProperty<bool> IsUIVisible => _isUIVisible;
        public IReadOnlyReactiveProperty<BonusTypeEnum> CurrentBonus => _currentBonus;

        public void SetUIVisible(bool visible)
        {
            _isUIVisible.Value = visible;
        }

        public void UpdateBonus(BonusTypeEnum points)
        {
            _currentBonus.Value = points;
        }
    }
}