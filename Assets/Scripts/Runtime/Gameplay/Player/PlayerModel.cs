using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Constants;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Runtime.Gameplay.Player
{
    public class PlayerModel : BaseModel, IPlayerModel
    {
        private IBallPresenter _ballPresenter;
        private ReactiveProperty<Vector3> _currentPosition = new ReactiveProperty<Vector3>(Vector3.zero);
        public IReadOnlyReactiveProperty<Vector3> CurrentPosition => _currentPosition;
        public IBallPresenter BallPresenter => _ballPresenter;

        public PlayerModel(IBallPresenter ballPresenter)
        {
            _ballPresenter = ballPresenter;
        }

        public void SetPosition(Vector3 pos)
        {
            _currentPosition.Value = pos;
            _ballPresenter.BallPosition = pos + GameConstants.BallOffset;
        }
    }
}