using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using UnityEngine;

namespace Assets.Scripts.Runtime.Gameplay.Ball
{
    public class BallModel : BaseModel, IBallModel
    {
        private Vector3 _startPosition;

        public Vector3 StartPosition
        {
            get => _startPosition;
            set
            {
                if (_startPosition == value) return;
                _startPosition = value;
                RaiseModelChanged();
            }
        }
    }
}