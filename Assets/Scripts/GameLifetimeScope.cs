using Survival;
using VContainer;
using VContainer.Unity;

namespace Survival
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<StandaloneInputHandler>(Lifetime.Singleton)
                .AsImplementedInterfaces();
        }
    }
}
