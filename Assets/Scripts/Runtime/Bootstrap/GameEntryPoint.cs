using Assets.Scripts.Runtime.Shared.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Assets.Scripts.Runtime.Bootstrap
{
    public class GameEntryPoint : IPostStartable
    {
        private readonly IGameManager _gameManager;

        public GameEntryPoint(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void PostStart()
        {
            Debug.Log("Game Entry Point Start called.");
        }
    }
}