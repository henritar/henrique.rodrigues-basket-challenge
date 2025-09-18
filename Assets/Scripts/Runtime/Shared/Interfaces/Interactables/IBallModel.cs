using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Shared.Interfaces.Interactables
{
    public interface IBallModel : IBaseModel
    {
        IReadOnlyReactiveProperty<Vector3> StartPosition { get; }
        void SetStartPosition(Vector3 pos);
    }
}