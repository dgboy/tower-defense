using Core.Base.Data;
using Core.States.Game.Movement;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

namespace Core.States.Game.Enemy {
    public class MonsterFactory {
        [Inject] private GeneralConfig Configs { get; set; }
        [Inject] private MovementSystem Movement { get; set; }
        [Inject] private LevelContext Level { get; set; }

        private int Counter { get; set; }


        public void Create(MonsterConfig config, Vector3 at, Transform parent) {
            var actor = Object.Instantiate(config.prefab, at, Quaternion.identity, parent);
            actor.name = $"{config.name} {Counter}";

            actor.speed = config.speed;
            actor.damage = config.damage;
            // Movement.Pool.Add(actor);

            var movement = actor.AddComponent<TrajectoryMovement>();
            movement.Actor = actor;
            movement.Level = Level;

            Counter++;
            Debug.Log($"{actor.name} is ready!");
        }
    }
}