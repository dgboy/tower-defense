using UnityEngine;

namespace Core.States.Game.Enemy {
    [CreateAssetMenu(menuName = "Game/Monster", fileName = "Monster")]
    public class MonsterConfig : ScriptableObject {
        public MonsterActor prefab;

        public float health = 1f;
        public float speed = 1f;
        public float damage = 1f;
    }
}