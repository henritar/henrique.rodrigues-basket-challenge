using Assets.Scripts.Runtime.Shared.Interfaces.MVP;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface IRewardMenuModel : IBaseModel
    {
        bool IsUIVisible { get; set; }
    }
}