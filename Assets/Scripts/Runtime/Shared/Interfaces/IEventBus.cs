using System;

namespace Assets.Scripts.Runtime.Shared.Interfaces
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IGameEvent;
        IObservable<TEvent> OnEvent<TEvent>() where TEvent : IGameEvent;
    }
}