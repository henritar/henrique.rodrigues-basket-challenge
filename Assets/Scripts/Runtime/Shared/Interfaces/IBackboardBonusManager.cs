namespace Assets.Scripts.Runtime.Shared.Interfaces
{
    public interface IBackboardBonusManager : IBaseManager
    {
        void StartBonusGeneration();
        void StopBonusGeneration();
    }
}