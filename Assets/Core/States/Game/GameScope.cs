using Core.Base;
using Core.Base.Data;
using Core.States.Game.Enemy;
using Core.States.Game.Movement;
using Core.States.Game.Player;
using DG_Pack.Base;
using VContainer;
using VContainer.Unity;

namespace Core.States.Game {
    public class GameScope : LifetimeScope {
        public GeneralConfig config;


        protected override void Configure(IContainerBuilder builder) {
            builder.RegisterInstance(config);
            builder.Register<RuntimeData>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<LevelContext>().AsSelf().As<ICoroutineRunner>();
            builder.Register<CoroutineCooldown>(Lifetime.Transient).As<ICooldown>();
            
            builder.Register<MovementSystem>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            // builder.Register<MusicService>(Lifetime.Scoped);
            // builder.Register<InputService>(Lifetime.Scoped).As<IInputService>();
            // builder.RegisterComponentInHierarchy<SmoothCamera>().As<ICameraService>();

            // builder.Register<ExodusService>(Lifetime.Scoped).AsSelf().As<IInitializable>();
            // builder.RegisterEntryPoint<DefeatSystem>();
            // builder.RegisterEntryPoint<VictorySystem>();

            // builder.RegisterComponentInHierarchy<UIDocumentTree>();
            RegisterPlayerScope(builder);
            RegisterMonsterScope(builder);

            builder.RegisterEntryPoint<GameStartup>();
        }


        private static void RegisterPlayerScope(IContainerBuilder builder) {
            builder.Register<TowerFactory>(Lifetime.Singleton);
        }
        private static void RegisterMonsterScope(IContainerBuilder builder) {
            builder.Register<MonsterFactory>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<MonsterSpawner>();
        }
    }
}