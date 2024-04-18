using System.Linq;
using Core.Base.Data;
using DG_Pack.Base;
using UnityEngine;
using VContainer;

namespace Core.States.Game.Enemy {
    public class MonsterSpawner : MonoBehaviour {
        [Inject] private GeneralConfig Configs { get; set; }
        [Inject] private LevelContext Level { get; set; }
        [Inject] private MonsterFactory Factory { get; set; }
        private ICooldown Cooldown { get; set; }

        [field: SerializeField] private float TotalHealth { get; set; }
        public float time = 3f;


        private void Start() {
            Cooldown = new Cooldown(this);
            TotalHealth = Level.enemy.totalHealth;
        }
        public void Update() {
            if (!Cooldown.IsExpired || TotalHealth <= 0)
                return;

            var pool = Configs.enemy.monsters.Where(x => x.health <= TotalHealth).ToList();
            if (pool.Count <= 0) {
                // Debug.Log($"{GetType().Name} Enemy Wave 0 is end");
                return;
            }

            var config = pool[Random.Range(0, pool.Count)];
            Factory.Create(config, Level.enemy.path[0].position, Level.runtimeParent);
            TotalHealth -= config.health;
            Cooldown.Start(time);
        }
    }
}