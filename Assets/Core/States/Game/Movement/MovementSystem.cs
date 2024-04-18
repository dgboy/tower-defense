using System.Collections.Generic;
using Core.States.Game.Enemy;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.States.Game.Movement {
    public class MovementSystem : IFixedTickable {
        [Inject] private LevelContext Level { get; set; }

        private const float MaxDistanceDelta = 0.1f;
        public List<MonsterActor> Pool { get; } = new();


        public void FixedTick() {
            foreach (var actor in Pool) {
                var from = actor.Rigidbody.position;
                Vector2 to = Level.enemy.path[actor.Target].position;
                float distance = Vector2.Distance(from, to);
                var direction = (to - from).normalized;

                if (distance > MaxDistanceDelta) {
                    // actor.Rigidbody.velocity = direction * actor.speed * Time.deltaTime;
                    actor.Rigidbody.MovePosition(from + direction * actor.speed * Time.fixedDeltaTime);
                } else if (actor.Target < Level.enemy.path.Length - 1) {
                    actor.Target++;
                    Debug.Log($"{actor.name} go to point {actor.Target}");
                }
            }
        }
    }
}