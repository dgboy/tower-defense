using System;
using UnityEngine;

namespace Core.States.Game.Common {
    [RequireComponent(typeof(CircleCollider2D))]
    public class Radar : MonoBehaviour {
        [field: SerializeField] public CircleCollider2D Collider { get; set; }

        public event Action<Collider2D> OnEnter;
        public event Action<Collider2D> OnStay;
        public event Action<Collider2D> OnExit;
        public float Range { get => Collider.radius; set => Collider.radius = value; }


        private void OnTriggerEnter2D(Collider2D other) {
            if (HasTargetTag(other))
                OnEnter?.Invoke(other);

            Debug.Log($"[{transform.parent.name}|{GetType().Name}] detected: {other.name}!");
        }
        private void OnTriggerStay2D(Collider2D other) {
            if (HasTargetTag(other))
                OnStay?.Invoke(other);
        }
        private void OnTriggerExit2D(Collider2D other) {
            if (HasTargetTag(other))
                OnExit?.Invoke(other);
        }

        private bool HasTargetTag(Component other) => other.CompareTag(tag);
    }
}