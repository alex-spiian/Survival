using UniTaskPubSub;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<AsyncMessageBus>(Lifetime.Singleton)
            .AsImplementedInterfaces()
            .AsSelf();
    }
}
