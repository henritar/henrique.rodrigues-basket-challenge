using Assets.Scripts.Runtime.Shared.Interfaces.InputSystem;

namespace Assets.Scripts.Runtime.Shared.Interfaces
{
    public interface IGameplayInputManager : IBaseManager, IInputManager<IGameplayInputHandler>
    {
    }
}