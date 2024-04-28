using System.Linq;
using Core.Base.Data;
using Core.Game.Exodus;
using Core.States.Game.Exodus;
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
        [Inject] private ExodusService ExodusService { get; set; }

        public float time = 3f;
        public float radius = 3f;


        public void Update() {
            if (Data.BattleMode.Value && Data.TotalHealth <= 0 && Data.Enemies.Count == 0) {
                ExodusService.Declare(ExodusID.Victory);
                // enabled = false;
                return;
            }

            if (!Cooldown.IsExpired || Data.TotalHealth <= 0)
                return;

            var pool = Configs.enemy.monsters.Where(x => x.health <= Data.TotalHealth).ToList();
            if (pool.Count <= 0) {
                Data.TotalHealth = 0;
                return;
            }

            var config = pool[Random.Range(0, pool.Count)];
            Factory.Create(config, GetRandomPointOnCircle(radius), Level.runtimeParent);
            Data.TotalHealth -= config.health;
            Cooldown.Start(time);
        }

        public void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Vector3.zero, radius);
        }

        private static Vector2 GetRandomPointOnCircle(float r) {
            int angle = Random.Range(0, 360);

            return new Vector2(
                r * Mathf.Cos(angle),
                r * Mathf.Sin(angle)
            );
        }
    }
}