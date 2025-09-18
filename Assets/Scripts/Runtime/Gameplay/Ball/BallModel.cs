using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Gameplay.Ball
{
    public class BallModel : BaseModel, IBallModel
    {
        private ReactiveProperty<Vector3> _startPosition = new();

        public IReadOnlyReactiveProperty<Vector3> StartPosition => _startPosition;

        public void SetStartPosition(Vector3 pos)
        {
            _startPosition.Value = pos;
        }
    }
}