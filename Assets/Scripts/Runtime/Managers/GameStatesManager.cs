using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared;
using Assets.Scripts.Runtime.Shared.Interfaces.StateMachine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Runtime.Managers
{
    public class GameStatesManager : BaseStateManager<GameStatesEnum>, IGameStateManager
    {
        public GameStatesManager(IEnumerable<IGameState> gameStates)
        {
            _states = gameStates.ToArray();

            _isInitialized = true;
        }
    }
}