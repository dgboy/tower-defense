using Core.States.Game.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace Core.States.Game.Player {
    public class PlayerBase : MonoBehaviour {
        public float maxHealth = 10;
        private float _health;
        public Slider healthBar;

        private void Start() {
            _health = maxHealth;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            var actor = other.GetComponent<MonsterActor>();

            _health -= actor.damageToBase;
            healthBar.value = _health / maxHealth;
            Debug.Log($"[{GetType().Name}] {actor.name} caused {actor.damageToBase} damage. {_health} HP left.");

            actor.Kill();

            if (_health > 0)
                return;

            Debug.Log($"[{GetType().Name}] base is destroyed!");
            gameObject.SetActive(false);
            Debug.Log("=== GAME OVER ===");
        }
    }
}