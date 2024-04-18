using Core.Base.Data;
using Core.States.Game.Movement;
using UnityEngine;
using VContainer;

namespace Core.States.Game.Enemy {
    public class MonsterFactory {
        [Inject] private GeneralConfig Configs { get; set; }
        [Inject] private MovementSystem Movement { get; set; }

        private int Counter { get; set; }


        public void Create(MonsterConfig config, Vector3 at, Transform parent) {
            var actor = Object.Instantiate(config.prefab, at, Quaternion.identity, parent);
            actor.name = $"{config.name} {Counter}";

            actor.speed = config.speed;
            actor.damage = config.damage;
            Movement.Pool.Add(actor);

            Counter++;
            Debug.Log($"{actor.name} is ready!");
        }
    }
}