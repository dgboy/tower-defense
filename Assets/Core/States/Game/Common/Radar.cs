using System;
using UnityEngine;

namespace Core.States.Game.Common {
    [RequireComponent(typeof(CircleCollider2D))]
    public class Radar : MonoBehaviour {
        [field: SerializeField] public CircleCollider2D Collider { get; set; }

        public event Action<Collider2D> Enter;
        public event Action<Collider2D> Exit;
        public float Range { get => Collider.radius; set => Collider.radius = value; }


        private void OnTriggerEnter2D(Collider2D other) {
            if (HasTargetTag(other))
                Enter?.Invoke(other);

            Debug.Log($"[{transform.parent.name}|{GetType().Name}] detected: {other.name}!");
        }
        private void OnTriggerExit2D(Collider2D other) {
            if (HasTargetTag(other))
                Exit?.Invoke(other);
        }

        private bool HasTargetTag(Component other) => other.CompareTag(tag);
    }
}