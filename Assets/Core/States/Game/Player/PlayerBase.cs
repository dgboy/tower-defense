using Core.Game.Exodus;
using Core.States.Game.Enemy;
using Core.States.Game.Exodus;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Core.States.Game.Player {
    public class PlayerBase : MonoBehaviour {
        [Inject] private ExodusService ExodusService { get; set; }

        public float maxHealth = 10;
        public Slider healthBar;
        private float _health;

        private void Start() {
            _health = maxHealth;
        }
        public void Restore() {
            _health = maxHealth;
            healthBar.value = _health / maxHealth;
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            var actor = other.GetComponent<MonsterActor>();

            _health -= actor.damageToBase;
            healthBar.value = _health / maxHealth;
            Debug.Log($"[{GetType().Name}] {actor.name} caused {actor.damageToBase} damage. {_health} HP left.");

            actor.Die();

            if (_health > 0)
                return;

            Debug.Log($"[{GetType().Name}] base is destroyed!");
            gameObject.SetActive(false);
            ExodusService.Declare(ExodusID.Defeat);
        }
    }
}