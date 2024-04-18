using Core.States.Game.Enemy;
using UnityEngine;

namespace Core.States.Game {
    public class LevelContext : MonoBehaviour {
        public EnemyContext enemy;
        public Transform runtimeParent;
    }
}