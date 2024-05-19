using Core.States.Game.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace Core.States.Game.Player {
    public class PlayerBase : MonoBehaviour {
        public float maxHealth = 10;
        public Slider healthBar;
        public float Health { get; private set; }

        private void Start() {
            Health = maxHealth;
        }
        public void Restore() {
            Health = maxHealth;
            healthBar.value = Health / maxHealth;
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            var actor = other.GetComponent<MonsterActor>();

            Health -= actor.damageToBase;
            healthBar.value = Health / maxHealth;
            Debug.Log($"[{GetType().Name}] {actor.name} caused {actor.damageToBase} damage. {Health} HP left.");

            actor.Die();

            if (Health <= 0)
                Kill();
        }

        private void Kill() {
            gameObject.SetActive(false);
            Debug.Log($"[{GetType().Name}] base is destroyed!");
        }
    }
}