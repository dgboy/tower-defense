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
        private MonsterConfig Config => Configs.enemy.monsters[0];
        [field:SerializeField] private float TotalHealth { get; set; }


        private void Start() {
            Cooldown = new Cooldown(this);
            TotalHealth = Level.enemyTotalHealth;
        }
        public void Update() {
            if (!Cooldown.IsExpired || TotalHealth < 0)
                return;

            var actor = Factory.Create(Config, Level.runtimeParent);
            TotalHealth -= Config.health;
            Cooldown.Start(1f);
        }
    }
}