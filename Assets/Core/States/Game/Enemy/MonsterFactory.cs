using Core.Base.Data;
using UnityEngine;
using VContainer;

namespace Core.States.Game.Enemy {
    public class MonsterFactory {
        [Inject] private GeneralConfig Configs { get; set; }

        private int Counter { get; set; } = 0;


        public MonsterActor Create(MonsterConfig config, Vector3 at, Transform parent) {
            var actor = Object.Instantiate(Configs.enemy.prefab, at, Quaternion.identity, parent);
            actor.name = $"{config.name} {Counter}";

            actor.speed = config.speed;
            Counter++;
            return actor;
        }
    }
}