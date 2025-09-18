using UniRx;

namespace Assets.Scripts.Runtime.Shared.Interfaces
{
    public interface ITimerManager: IBaseManager
    {
        public IReadOnlyReactiveProperty<float> Timer { get; }
        void SetInitialTimer(int time);
    }
}