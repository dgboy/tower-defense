using Core.Base.Data;
using UnityEngine;
using VContainer;

namespace Core.States.Game.Enemy {
    public class MonsterFactory {
        [Inject] private GeneralConfig Configs { get; set; }

        private int Counter { get; set; } = 0;


        public MonsterActor Create(MonsterConfig config, Transform parent) {
            var actor = Object.Instantiate(Configs.enemy.prefab, parent);
            actor.name = $"{config.name} {Counter}";

            // actor.movement.speed = config.speed;
            Counter++;
            return actor;
        }
    }
}