using Core.States.Game.Enemy;
using UnityEngine;

namespace Core.States.Game.Player {
    public class PlayerBase : MonoBehaviour {
        public float health = 10;

        private void OnTriggerEnter2D(Collider2D other) {
            if (health <= 0) {
                Debug.Log($"[{GetType().Name}] base is destroyed!");
                gameObject.SetActive(false);
                return;
            }

            var actor = other.GetComponent<MonsterActor>();
            health -= actor.damage;
            Debug.Log($"[{GetType().Name}] {actor.name} caused {actor.damage} damage. {health} HP left.");
            // Destroy(actor.gameObject);
        }
    }
}