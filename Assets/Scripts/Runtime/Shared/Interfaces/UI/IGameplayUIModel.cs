using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UniRx;

namespace Assets.Scripts.Runtime.Shared.Interfaces.UI
{
    public interface IGameplayUIModel : IBaseModel
    {
        IReadOnlyReactiveProperty<int> CurrentPoints { get; }
        IReadOnlyReactiveProperty<bool> IsUIVisible { get; }
        void UpdatePoints(int points);
        void SetUIVisible(bool visible);

    }
}