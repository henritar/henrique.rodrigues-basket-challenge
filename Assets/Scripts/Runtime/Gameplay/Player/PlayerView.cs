using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using UnityEngine;

namespace Assets.Scripts.Runtime.Gameplay.Player
{
    public class PlayerView : BaseView, IPlayerView
    {
        public Vector3 CurrentPosition => transform.position;

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetRotation(Vector3 rotation)
        {
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}