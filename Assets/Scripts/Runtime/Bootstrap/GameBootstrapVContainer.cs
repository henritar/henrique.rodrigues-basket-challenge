using Assets.Scripts.Runtime.Managers;
using Assets.Scripts.Runtime.Shared.Interfaces.StateMachine;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.Runtime.Bootstrap
{
    public class GameBootstrapVContainer : LifetimeScope
    {
        // Start is called before the first frame update
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameManager>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameStatesManager>(Lifetime.Singleton).As<IGameStateManager>();

            builder.Register<GameEntryPoint>(Lifetime.Singleton);
            builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
