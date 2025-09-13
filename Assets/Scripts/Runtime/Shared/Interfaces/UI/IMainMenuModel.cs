using Assets.Scripts.Runtime.Shared.Interfaces.MVP;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface IMainMenuModel : IBaseModel
    {
        bool IsUIVisible { get; set; }
    }
}