using Assets.Scripts.Runtime.Enums;
using Assets.Scripts.Runtime.Shared.Interfaces.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Runtime.Managers.States.MainGame
{
    public class NoneGameState : IGameState
    {
        public GameStatesEnum State => GameStatesEnum.None;

        public void EnterState()
        {
            Debug.Log("Entering None Game State");
        }

        public void ExitState()
        {
            Debug.Log("Exiting None Game State");
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }
    }
}