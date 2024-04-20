using Core.States.Game.Enemy;
using UnityEngine;

namespace Core.States.Game.Player {
    public class PlayerBase : MonoBehaviour {
        public float health = 10;

        private void OnTriggerEnter2D(Collider2D other) {
            var actor = other.GetComponent<MonsterActor>();
            health -= actor.damage;
            actor.Kill();
            Debug.Log($"[{GetType().Name}] {actor.name} caused {actor.damage} damage. {health} HP left.");

            if (health > 0)
                return;

            Debug.Log($"[{GetType().Name}] base is destroyed!");
            gameObject.SetActive(false);
            // decline defeat
            Debug.Log("=== GAME OVER ===");
        }
    }
}