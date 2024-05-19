using UnityEngine;
using VContainer;

namespace Core.States.Game.Spawn {
    public class RandomSpawnPointOnCircle : MonoBehaviour, ISpawnPoint {
        [Inject] private LevelContext Level { get; set; }

        public float radius = 5f;
        public Vector3 Position => GetRandomPointOnCircle(radius);

        public void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Vector3.zero, radius);
        }

        private static Vector2 GetRandomPointOnCircle(float r) {
            int angle = Random.Range(0, 360);

            return new Vector2(
                r * Mathf.Cos(angle),
                r * Mathf.Sin(angle)
            );
        }
    }
}