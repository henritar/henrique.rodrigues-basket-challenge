using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using UnityEngine;

namespace Assets.Scripts.Runtime.Gameplay.Ball
{
    public class BallPresenter : BasePresenter<IBallModel, IBallView>, IBallPresenter
    {
        public Vector3 BallPosition => View.Transform.position;

        public BallPresenter(IBallModel model, IBallView view) : base(model, view)
        {
        }

        public void SetBallVelocity(Vector3 velocity)
        {
            var rb = View.Rigidbody;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = true;
            rb.velocity = velocity;
            rb.isKinematic = false;
        }

        private void ResetBallPosition()
        {
            var rb = View.Rigidbody;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
            rb.isKinematic = true;
            View.Transform.position = Model.StartPosition;
        }

        protected override void Initialize()
        {
            Model.StartPosition = View.Transform.position;
        }

        protected override void SubscribeToEvents()
        {
        }

        protected override void UnsubscribeFromEvents()
        {

        }
    }
}