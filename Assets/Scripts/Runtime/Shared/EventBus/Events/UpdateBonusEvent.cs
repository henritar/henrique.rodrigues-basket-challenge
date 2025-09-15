using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared.Interfaces;

namespace Assets.Scripts.Runtime.Shared.EventBus.Events
{
    public class UpdateBonusEvent : IGameEvent
    {
        public BonusTypeEnum Bonus { get; private set; }

        public UpdateBonusEvent(BonusTypeEnum bonus)
        {
            Bonus = bonus;
        }
    }
}