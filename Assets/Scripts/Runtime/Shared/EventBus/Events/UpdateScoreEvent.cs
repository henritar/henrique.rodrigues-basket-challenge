using Assets.Scripts.Runtime.Shared.Interfaces;

namespace Assets.Scripts.Runtime.Shared.EventBus.Events
{
    public class UpdateScoreEvent : IGameEvent
    {
        public int Points { get; private set; }

        public UpdateScoreEvent(int points)
        {
            Points = points;
        }
    }
}