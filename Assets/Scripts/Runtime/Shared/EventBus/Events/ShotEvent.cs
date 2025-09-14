using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Gameplay.Ball;
using Assets.Scripts.Runtime.Shared.Interfaces;

namespace Assets.Scripts.Runtime.Shared.EventBus.Events
{
    public class ShotEvent : IGameEvent
    {
        public BallPresenter Ball { get; private set; }
        public ShotResultEnum ShotResult { get; private set; }

        public ShotEvent(BallPresenter ball, ShotResultEnum shotResult)
        {
            Ball = ball;
            ShotResult = shotResult;
        }
    }
}