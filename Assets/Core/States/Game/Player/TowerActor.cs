using Core.States.Game.Common;
using UnityEngine;

namespace Core.States.Game.Player {
    public class TowerActor : MonoBehaviour {
        [field: SerializeField] public Radar Radar { get; set; }
        [field: SerializeField] public Shooting Shooting { get; set; }
        public float damage;
        public float rate;

        public void Init() {
            Radar.OnStay += Shooting.Track;
            // Radar.OnEnter += Shooting.Track;
            // Radar.OnExit += Shooting.Untrack;
        }

        private void OnDestroy() {
            Radar.OnStay -= Shooting.Track;
            // Radar.OnEnter -= Shooting.Track;
            // Radar.OnExit -= Shooting.Untrack;
        }
        
        
        public void OnDrawGizmos() {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(Vector3.zero, Radar.Range);
        }
    }
}