using System;

namespace Assets.Scripts.Runtime.Shared.Interfaces.StateMachine
{
    public interface IStatesManager<TStateEnum> : IBaseManager, IDisposable where TStateEnum : Enum
    {
        public TStateEnum CurrentState { get; }
        public void ChangeState(TStateEnum newState);
        public void Update();
        public void FixedUpdate();
    }
}