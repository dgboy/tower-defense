using System;
using Core.States.Game.Enemy;
using DG_Pack.Base;
using Unity.VisualScripting;
using UnityEngine;

namespace Core.States.Game.Common {
    public class Projectile : MonoBehaviour, ICoroutineRunner {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; set; }
        public float speed = 1f;
        public float damage;

        public MonsterActor Target { get; set; }
        private ICooldown Lifetime { get; set; }

        private void Start() {
            Lifetime = new CoroutineCooldown(this);
            Lifetime.Start(5f);
        }
        public void FixedUpdate() {
            if (Lifetime.IsExpired)
                KillSelf();

            if (Target == null)
                return;

            var from = Rigidbody.position;
            Vector2 to = Target.transform.position;
            float distance = Vector2.Distance(from, to);
            var direction = (to - from).normalized;

            if (distance > 0.1f) {
                // Rigidbody.velocity = direction * Actor.speed * Time.deltaTime;
                Rigidbody.MovePosition(from + direction * (speed * Time.fixedDeltaTime));
            } else {
                Target.TakeDamage(damage);
                KillSelf();
            }
        }

        private void KillSelf() {
            Destroy(gameObject);
        }
    }
}