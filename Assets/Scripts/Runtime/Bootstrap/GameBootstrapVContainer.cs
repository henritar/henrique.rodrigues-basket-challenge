using Assets.Scripts.Runtime.Managers;
using Assets.Scripts.Runtime.Managers.States.MainGame;
using Assets.Scripts.Runtime.Shared.Interfaces.StateMachine;
using Assets.Scripts.Runtime.Shared.Interfaces.UI;
using Assets.Scripts.Runtime.UI.MainMenu;
using Assets.Scripts.Runtime.UI.RewardMenu;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.Runtime.Bootstrap
{
    public class GameBootstrapVContainer : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Managers
                builder.Register<GameManager>(Lifetime.Singleton).AsImplementedInterfaces();
                builder.Register<GameStatesManager>(Lifetime.Singleton).As<IGameStateManager>();

            // Game States
                builder.Register<NoneGameState>(Lifetime.Singleton).As<IGameState>();
                builder.Register<MainMenuGameState>(Lifetime.Singleton).As<IGameState>();
                builder.Register<PlayingGameState>(Lifetime.Singleton).As<IGameState>();
                builder.Register<RewardGameState>(Lifetime.Singleton).As<IGameState>();

            // UI
                builder.RegisterComponentInHierarchy<MainMenuView>().As<IMainMenuView>();
                builder.Register<MainMenuModel>(Lifetime.Singleton).As<IMainMenuModel>();
                builder.Register<MainMenuPresenter>(Lifetime.Singleton).As<IMainMenuPresenter>();

                builder.RegisterComponentInHierarchy<RewardMenuView>().As<IRewardMenuView>();
                builder.Register<RewardMenuModel>(Lifetime.Singleton).As<IRewardMenuModel>();
                builder.Register<RewardMenuPresenter>(Lifetime.Singleton).As<IRewardMenuPresenter>();

            // Entry Point
                builder.Register<GameEntryPoint>(Lifetime.Singleton);
                builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
