using System;

namespace Assets.Scripts.Runtime.Shared.Interfaces.StateMachine
{
    public interface IStatesManager<TStateEnum> : IBaseManager, IDisposable where TStateEnum : Enum
    {
        TStateEnum CurrentState { get; }
        void ChangeState(TStateEnum newState);
        void Update();
        void FixedUpdate();
    }
}