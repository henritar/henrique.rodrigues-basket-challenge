using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Managers.States.MainGame;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.StateMachine;

namespace Assets.Scripts.Runtime.Managers
{
    public class GameStatesManager : BaseStateManager<GameStatesEnum>, IGameStateManager
    {
        public GameStatesManager()
        {
            _states = new IGameState[]
            {
                new NoneGameState(),
                new MainMenuGameState(this),
                new PlayingGameState(this),
                new RewardGameState(this),
            };

            _isInitialized = true;
        }
    }
}