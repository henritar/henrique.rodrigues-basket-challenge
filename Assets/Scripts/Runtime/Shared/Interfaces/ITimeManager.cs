using UniRx;

namespace Assets.Scripts.Runtime.Shared.Interfaces
{
    public interface ITimeManager: IBaseManager
    {
        public IReadOnlyReactiveProperty<float> Timer { get; }
    }
}