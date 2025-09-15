using Assets.Scripts.Runtime.Gameplay.Ball;
using Assets.Scripts.Runtime.Shared.Interfaces.MVP;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Shared.Interfaces.Interactables
{
    public interface IPlayerModel : IBaseModel
    {
        public IBallPresenter BallPresenter { get; }
        public IReadOnlyReactiveProperty<Vector3> CurrentPosition { get; }
        public void SetPosition(Vector3 pos);
    }
}