using UnityEngine;

namespace Assets.Scripts.Runtime.Shared.Interfaces.Interactables
{
    public interface IPlayerPresenter
    {
        void MoveToPosition(Vector3 xPosition);
        IBallPresenter GetBall();
    }
}