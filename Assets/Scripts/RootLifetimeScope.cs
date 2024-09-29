using Survival.Inventory;
using UniTaskPubSub;
using VContainer;
using VContainer.Unity;

namespace Survival
{
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
}
