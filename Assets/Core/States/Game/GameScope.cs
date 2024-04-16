using Core.Base;
using Core.Base.Data;
using VContainer;
using VContainer.Unity;

namespace Core.States.Game {
    public class GameScope : LifetimeScope {
        public GeneralConfig config;


        protected override void Configure(IContainerBuilder builder) {
            builder.RegisterInstance(config);
            builder.Register<RuntimeData>(Lifetime.Scoped);

            // builder.Register<MusicService>(Lifetime.Scoped);
            // builder.Register<InputService>(Lifetime.Scoped).As<IInputService>();
            // builder.RegisterComponentInHierarchy<SmoothCamera>().As<ICameraService>();

            // builder.Register<ExodusService>(Lifetime.Scoped).AsSelf().As<IInitializable>();
            // builder.RegisterEntryPoint<DefeatSystem>();
            // builder.RegisterEntryPoint<VictorySystem>();

            builder.RegisterComponentInHierarchy<LevelContext>();
            // builder.RegisterComponentInHierarchy<UIDocumentTree>();

            builder.RegisterEntryPoint<GameStartup>();
        }
    }
}