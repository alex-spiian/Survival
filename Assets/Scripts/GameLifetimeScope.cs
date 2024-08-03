using InputHandler;
using UniTaskPubSub;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<StandaloneInputHandler>(Lifetime.Singleton)
            .AsImplementedInterfaces();
        
        builder.Register<AsyncMessageBus>(Lifetime.Singleton)
            .AsImplementedInterfaces()
            .AsSelf();
    }
}
