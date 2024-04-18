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
        private MonsterConfig Config => Configs.enemy.monsters[0];


        private void Start() {
            Cooldown = new Cooldown(this);
            TotalHealth = Level.enemy.totalHealth;
        }
        public void Update() {
            if (!Cooldown.IsExpired || TotalHealth <= 0)
                return;

            Factory.Create(Config, Level.enemy.path[0].position, Level.runtimeParent);
            TotalHealth -= Config.health;
            Cooldown.Start(time);
        }
    }
}