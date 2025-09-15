using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UniRx;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface IBackboardBonusUIModel : IBaseModel
    {
        IReadOnlyReactiveProperty<bool> IsUIVisible { get; }
        IReadOnlyReactiveProperty<BonusTypeEnum> CurrentBonus { get; }
        void UpdateBonus(BonusTypeEnum points);
        void SetUIVisible(bool visible);
    }
}