using Assets.Scripts.Runtime.Shared;

namespace Assets.Scripts.Runtime.UI.GameplayUI
{
    public class GameplayUIModel : BaseModel
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