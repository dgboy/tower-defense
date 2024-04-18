using UnityEngine;

namespace Core.States.Game.Enemy {
    public class MonsterActor : MonoBehaviour {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; set; }
        
        public float speed;
        public float damage;
        public int Target { get; set; } = 1;
    }
}