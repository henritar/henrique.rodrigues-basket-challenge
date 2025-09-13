using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;

namespace Assets.Scripts.Runtime.UI.MainMenu
{
    public class MainMenuModel : BaseModel, IMainMenuModel
    {
        private bool _isUIVisible;

        public bool IsUIVisible
        {
            get => _isUIVisible;
            set
            {
                if (_isUIVisible == value) return;
                _isUIVisible = value;
                RaiseModelChanged();
            }
        }
    }
}