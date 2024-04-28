using Core.Base.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Core.States.Game.Enemy {
    public class MonsterActor : MonoBehaviour {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; set; }
        [field: SerializeField] public Slider HealthBar { get; set; }
        public RuntimeData Data { get; set; }

        public float speed;
        public float damageToBase;
        public float maxHealth;
        public float health;


        public void TakeDamage(float damage) {
            health -= damage;
            HealthBar.value = health / maxHealth;
            Debug.Log($"[{name}] HP {health}/{maxHealth}");

            if (health <= 0)
                Die();
        }

        public void Die() {
            Destroy(gameObject);
            
            Data.Enemies.Remove(this); // mega kostil!
        }
    }
}