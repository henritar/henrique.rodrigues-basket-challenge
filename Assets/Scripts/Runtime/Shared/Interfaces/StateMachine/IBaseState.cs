using System;

namespace Assets.Scripts.Runtime.Shared.Interfaces.StateMachine
{
    public interface IBaseState<TStateEnum> where TStateEnum : Enum
    {
        public TStateEnum State { get; }
        public void EnterState();
        public void ExitState();
        public void Update();
        public void FixedUpdate();
    }
}