using VContainer;
using VContainer.Unity;

namespace Core.States.Home {
    public class HomeScope : LifetimeScope {
        protected override void Configure(IContainerBuilder builder) {
            builder.RegisterComponentInHierarchy<HomeScreen>();
        }
    }
}