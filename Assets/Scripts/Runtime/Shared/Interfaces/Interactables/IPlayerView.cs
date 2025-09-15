using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UnityEngine;

namespace Assets.Scripts.Runtime.Shared.Interfaces.Interactables
{
    public interface IPlayerView : IBaseView
    {
        Vector3 CurrentPosition { get; }
        void SetPosition(Vector3 position);
        void SetRotation(Vector3 rotation);
    }
}