using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using System;
using UniRx;

namespace Assets.Scripts.Runtime.UI.GameplayUI
{
    public class GameplayUIModel : BaseModel, IGameplayUIModel
    {
        private readonly ReactiveProperty<bool> _isUIVisible = new ReactiveProperty<bool>(false);

        private readonly ReactiveProperty<int> _currentPoints = new ReactiveProperty<int>();

        public IReadOnlyReactiveProperty<bool> IsUIVisible => _isUIVisible;
        public IReadOnlyReactiveProperty<int> CurrentPoints => _currentPoints;

        public void SetUIVisible(bool visible)
        {
            _isUIVisible.Value = visible;
        }

        public void UpdatePoints(int points)
        {
            _currentPoints.Value = points;
        }
    }

}