using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.StateMachine;

namespace Assets.Scripts.Runtime.Shared
{
    public abstract class BaseGameState : IGameState
    {
        protected IStatesManager<GameStatesEnum> _stateManager;
        public GameStatesEnum State => GameState;

        public void SetStateManager(IStatesManager<GameStatesEnum> stateManager)
        {
            _stateManager = stateManager;
        }

        public void EnterState()
        {
            OnEnterState();
        }

        public void ExitState()
        {
            OnExitState();
        }

        public void FixedUpdate()
        {
            OnFixedUpdate();
        }
        public void Update()
        {
            OnUpdate();
        }
        protected abstract GameStatesEnum GameState { get; }
        protected abstract void OnEnterState();
        protected abstract void OnExitState();
        protected abstract void OnFixedUpdate();
        protected abstract void OnUpdate();

    }
}