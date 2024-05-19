using Core.Base.Data;
using Core.Game.Exodus;
using Core.States.Game.Enemy;
using Core.States.Game.Player;
using DG_Pack.Services.Log;
using VContainer;
using VContainer.Unity;

namespace Core.States.Game.Exodus {
    public class ExodusService : ITickable {
        [Inject] private ICustomLogger Logger { get; set; }
        [Inject] private GeneralConfig Configs { get; set; }
        [Inject] private LevelContext Context { get; set; }
        [Inject] private RuntimeData Data { get; set; }
        [Inject] private EnemyWave EnemyWave { get; set; }
        [Inject] private PlayerBase PlayerBase { get; set; }

        public void Tick() {
            if (!Data.BattleMode.Value) return;

            if (EnemyWave.Health <= 0 && Data.Enemies.Count == 0)
                Declare(ExodusID.Victory);
            else if (PlayerBase.Health <= 0)
                Declare(ExodusID.Defeat);
        }

        private void Declare(ExodusID id) {
            Data.BattleMode.Value = false;
            Data.BattleState.Value = 0;

            if (id == ExodusID.Victory)
                EnemyWave.Counter.Value++;
            else
                EnemyWave.Counter.Value = 1;

            // Logger.Log($"Enemy Wave is end");
            Logger.Log($"=== {id} ===", Dye.Red);
        }
    }
}