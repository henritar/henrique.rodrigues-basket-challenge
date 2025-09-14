using Assets.Scripts.Runtime.Shared.Interfaces.InputSystem;
using UnityEngine;
namespace Assets.Scripts.Runtime.Shared.Interfaces
{
    public interface IGameplayInputManager : IBaseManager, IInputManager<IGameplayInputHandler>
    {
        Vector2 PointerPosition { get; }
    }
}