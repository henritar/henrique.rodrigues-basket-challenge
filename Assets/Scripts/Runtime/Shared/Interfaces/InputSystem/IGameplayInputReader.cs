using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Runtime.Shared.Interfaces.InputSystem
{
    public interface IGameplayInputReader : IInputReader
    {
        public Vector2 PointerPosition { get; }
        public event UnityAction PlainClicked;
        public event UnityAction ClickHolded;
        public event UnityAction ClickRelease;
    }
}