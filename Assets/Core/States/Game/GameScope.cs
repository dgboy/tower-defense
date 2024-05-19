using Core.Base.Data;
using Core.States.Game.Common;
using Core.States.Game.Enemy;
using Core.States.Game.Exodus;
using Core.States.Game.Player;
using Core.States.Game.Spawn;
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
            
            builder.Register<CertainSpawnPoint>(Lifetime.Singleton).AsSelf().As<ISpawnPoint>();

            RegisterPlayerScope(builder);
            RegisterEnemyScope(builder);

            builder.Register<ExodusService>(Lifetime.Singleton).AsSelf().As<ITickable>();
            builder.RegisterComponentInHierarchy<GameHUD>();
            builder.RegisterEntryPoint<GameStartup>();
        }


        private static void RegisterPlayerScope(IContainerBuilder builder) {
            builder.Register<TowerFactory>(Lifetime.Singleton);
            builder.Register<TowerProjectileFactory>(Lifetime.Singleton);

            builder.RegisterComponentInHierarchy<PlayerBase>();
        }
        private static void RegisterEnemyScope(IContainerBuilder builder) {
            builder.Register<MonsterFactory>(Lifetime.Singleton);
            builder.Register<EnemyWave>(Lifetime.Singleton);
            
            builder.RegisterComponentInHierarchy<EnemyBase>();
            builder.RegisterComponentInHierarchy<MonsterSpawner>();
        }
    }
}