using Assets.Scripts.Runtime.Shared.Interfaces;

namespace Assets.Scripts.Runtime.Shared.EventBus.Events
{
    public class GoalEvent : IGameEvent
    {
        public int Points { get; private set; }

        public GoalEvent(int points)
        {
            Points = points;
        }
    }
}