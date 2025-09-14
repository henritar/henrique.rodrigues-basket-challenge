using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using UniRx;

namespace Assets.Scripts.Runtime.UI.MainMenu
{
    public class MainMenuModel : BaseModel, IMainMenuModel
    {
        private readonly ReactiveProperty<bool> _isUIVisible = new ReactiveProperty<bool>(false);

        public IReadOnlyReactiveProperty<bool> IsUIVisible => _isUIVisible;

        public void SetUIVisible(bool visible)
        {
            _isUIVisible.Value = visible;
        }
    }
}