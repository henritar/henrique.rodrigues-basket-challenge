using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UnityEngine;

namespace Assets.Scripts.Runtime.Shared.Interfaces.Interactables
{
    public interface IBallPresenter : IBasePresenter
    {
        Vector3 BallPosition { get; }
        void SetBallVelocity(Vector3 velocity);
    }
}