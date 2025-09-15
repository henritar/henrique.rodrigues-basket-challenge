using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared.Interfaces.MVP;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface IBackboardBonusUIView : IBaseView
    {
        void EnableBonus(BonusTypeEnum bonusType);
    }
}