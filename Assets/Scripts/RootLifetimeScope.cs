using Inventory;
using UniTaskPubSub;
using VContainer;
using VContainer.Unity;

public class RootLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<InventoryModel>(Lifetime.Singleton);

        builder.Register<AsyncMessageBus>(Lifetime.Singleton)
            .AsImplementedInterfaces()
            .AsSelf();
    }
}
