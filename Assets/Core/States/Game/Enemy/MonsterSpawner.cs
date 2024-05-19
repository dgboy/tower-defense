using System.Linq;
using Core.Base.Data;
using Core.States.Game.Spawn;
using DG_Pack.Base;
using UnityEngine;
using VContainer;

namespace Core.States.Game.Enemy {
    public class MonsterSpawner : MonoBehaviour {
        [Inject] private GeneralConfig Configs { get; set; }
        [Inject] private LevelContext Level { get; set; }
        [Inject] private RuntimeData Data { get; set; }
        [Inject] private MonsterFactory Factory { get; set; }
        [Inject] private ICooldown Cooldown { get; set; }
        [Inject] private ISpawnPoint SpawnPoint { get; set; }

        public float time = 3f;


        public void Update() {
            if (!Cooldown.IsExpired || Data.TotalHealth <= 0)
                return;

            var pool = Configs.enemy.monsters.Where(x => x.health <= Data.TotalHealth).ToList();
            if (pool.Count <= 0) {
                Data.TotalHealth = 0;
                return;
            }

            var config = pool[Random.Range(0, pool.Count)];
            Factory.Create(config, SpawnPoint.Position, Level.runtimeParent);
            Data.TotalHealth -= config.health;
            Cooldown.Start(time);
        }
    }
}