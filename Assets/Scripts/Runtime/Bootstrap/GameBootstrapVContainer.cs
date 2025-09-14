using Assets.Scripts.Runtime.Gameplay.Ball;
using Assets.Scripts.Runtime.Gameplay.Interactables;
using Assets.Scripts.Runtime.InputSystem.Gameplay;
using Assets.Scripts.Runtime.Managers;
using Assets.Scripts.Runtime.Managers.States.MainGame;
using Assets.Scripts.Runtime.ScriptableObjects.InputSystem;
using Assets.Scripts.Runtime.Shared.EventBus;
using Assets.Scripts.Runtime.Shared.Interfaces;
using Assets.Scripts.Runtime.Shared.Interfaces.InputSystem;
using Assets.Scripts.Runtime.Shared.Interfaces.InputSystem.Gameplay;
using Assets.Scripts.Runtime.Shared.Interfaces.Interactables;
using Assets.Scripts.Runtime.Shared.Interfaces.StateMachine;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using Assets.Scripts.Runtime.UI.GameplayUI;
using Assets.Scripts.Runtime.UI.MainMenu;
using Assets.Scripts.Runtime.UI.RewardMenu;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.Runtime.Bootstrap
{
    public class GameBootstrapVContainer : LifetimeScope
    {
        [SerializeField] private SO_GameplayInputReader _gameplayInputReader;

        protected override void Configure(IContainerBuilder builder)
        {
            // Scriptable Objects
                builder.RegisterInstance(_gameplayInputReader).As<IGameplayInputReader>().AsSelf();

            // Managers
                builder.Register<GameManager>(Lifetime.Singleton).AsImplementedInterfaces();
                builder.Register<GoalManager>(Lifetime.Singleton).AsImplementedInterfaces();
                builder.Register<ShotManager>(Lifetime.Singleton).AsImplementedInterfaces();
                builder.Register<GameplayInputManager>(Lifetime.Singleton).AsImplementedInterfaces();
                builder.Register<GameStatesManager>(Lifetime.Singleton).As<IGameStateManager>();

            // Event Bus
                builder.Register<EventBus>(Lifetime.Singleton).As<IEventBus>();

            // Game States
                builder.Register<NoneGameState>(Lifetime.Singleton).As<IGameState>();
                builder.Register<MainMenuGameState>(Lifetime.Singleton).As<IGameState>();
                builder.Register<PlayingGameState>(Lifetime.Singleton).As<IGameState>();
                builder.Register<RewardGameState>(Lifetime.Singleton).As<IGameState>();

            //Interactables
                builder.RegisterComponentInHierarchy<BasketColliderDetector>().As<IBasketDetector>();
                builder.RegisterComponentInHierarchy<BasketPoint>().As<IBasketPoint>();
                builder.RegisterComponentInHierarchy<BackboardPoint>().As<IBackboardPoint>();

            // Ball
                builder.RegisterComponentInHierarchy<BallView>().As<IBallView>();
                builder.Register<BallModel>(Lifetime.Singleton).As<IBallModel>();
                builder.Register<BallPresenter>(Lifetime.Singleton).AsImplementedInterfaces();

            // UI
                builder.RegisterComponentInHierarchy<MainMenuView>().As<IMainMenuView>();
                builder.Register<MainMenuModel>(Lifetime.Singleton).As<IMainMenuModel>();
                builder.Register<MainMenuPresenter>(Lifetime.Singleton).AsImplementedInterfaces();

                builder.RegisterComponentInHierarchy<RewardMenuView>().As<IRewardMenuView>();
                builder.Register<RewardMenuModel>(Lifetime.Singleton).As<IRewardMenuModel>();
                builder.Register<RewardMenuPresenter>(Lifetime.Singleton).AsImplementedInterfaces();

                builder.RegisterComponentInHierarchy<GameplayUIView>().As<IGameplayUIView>();
                builder.Register<GameplayUIModel>(Lifetime.Singleton).As<IGameplayUIModel>();
                builder.Register<GameplayUIPresenter>(Lifetime.Singleton).AsImplementedInterfaces();

            // Input Handlers
            builder.Register<Gameplay_PlayingInputHandler>(Lifetime.Singleton).As<IPlayingInputHandler>();

            // Entry Point
                builder.Register<GameEntryPoint>(Lifetime.Singleton);
                builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
