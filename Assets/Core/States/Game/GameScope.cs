using Core.Base.Data;
using Core.States.Game.Common;
using Core.States.Game.Enemy;
using Core.States.Game.Exodus;
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

            RegisterPlayerScope(builder);
            RegisterEnemyScope(builder);

            builder.Register<ExodusService>(Lifetime.Singleton);
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
            
            builder.RegisterComponentInHierarchy<MonsterSpawner>();
        }
    }
}