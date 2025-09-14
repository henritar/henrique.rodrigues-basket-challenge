using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UniRx;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface IMainMenuModel : IBaseModel
    {
        public IReadOnlyReactiveProperty<bool> IsUIVisible { get; }
        public void SetUIVisible(bool visible);
    }
}