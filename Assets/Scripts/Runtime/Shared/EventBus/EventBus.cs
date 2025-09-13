using Assets.Scripts.Runtime.Shared.Interfaces;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Shared.EventBus
{
    public class EventBus : IEventBus, IDisposable
    {
        private readonly Subject<IGameEvent> _eventStream = new();

        public void Publish<TEvent>(TEvent @event) where TEvent : IGameEvent
        {
            if (@event == null)
            {
                Debug.LogWarning("Attempted to publish a null event.");
                return;
            }
            _eventStream.OnNext(@event);
        }

        public IObservable<TEvent> OnEvent<TEvent>() where TEvent : IGameEvent
        {
            return _eventStream.OfType<IGameEvent, TEvent>();
        }

        public void Dispose()
        {
            _eventStream.OnCompleted(); 
            _eventStream.Dispose();   
        }
    }
}