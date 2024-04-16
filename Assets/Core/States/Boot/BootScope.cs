using VContainer;
using VContainer.Unity;

namespace Core.States.Boot {
    public class BootScope : LifetimeScope {
        protected override void Configure(IContainerBuilder builder) {
            builder.RegisterEntryPoint<EntryPoint>();
        }
    }
}