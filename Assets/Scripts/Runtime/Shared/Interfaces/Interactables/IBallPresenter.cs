using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Shared.Interfaces.Interactables
{
    public interface IBallPresenter : IBasePresenter
    {
        Vector3 BallPosition { get; set; }
        void SetBallVelocity(Vector3 velocity);
        IObservable<Unit> OnBallReset { get; }
    }
}