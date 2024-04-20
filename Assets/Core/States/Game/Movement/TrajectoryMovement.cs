using Core.States.Game.Enemy;
using UnityEngine;

namespace Core.States.Game.Movement {
    public class TrajectoryMovement : MonoBehaviour {
        public MonsterActor Actor { get; set; }
        public LevelContext Level { get; set; }

        private int CurrentGoal { get; set; } = 1;
        private const float MaxDistanceDelta = 0.1f;


        public void FixedUpdate() {
            var from = Actor.Rigidbody.position;
            Vector2 to = Level.enemy.path[CurrentGoal].position;
            float distance = Vector2.Distance(from, to);
            var direction = (to - from).normalized;

            if (distance > MaxDistanceDelta) {
                // Actor.Rigidbody.velocity = direction * Actor.speed * Time.deltaTime;
                Actor.Rigidbody.MovePosition(from + direction * (Actor.speed * Time.fixedDeltaTime));
            } else if (CurrentGoal < Level.enemy.path.Length - 1) {
                CurrentGoal++;
                // Debug.Log($"{Actor.name} go to point {Actor.Target}");
            }
        }
    }
}