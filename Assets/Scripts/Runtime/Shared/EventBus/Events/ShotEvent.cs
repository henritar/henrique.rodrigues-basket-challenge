using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;

namespace Assets.Scripts.Runtime.Shared.EventBus.Events
{
    public class ShotEvent : IGameEvent
    {
        public IBallPresenter BallPresenter { get; private set; }
        public ShotResultEnum ShotResult { get; private set; }

        public ShotEvent(IBallPresenter ball, ShotResultEnum shotResult)
        {
            BallPresenter = ball;
            ShotResult = shotResult;
        }
    }
}