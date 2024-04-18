using System;
using Core.States.Game.Enemy;
using UnityEngine;

namespace Core.States.Game {
    public class LevelContext : MonoBehaviour {
        public Transform runtimeParent;
        public EnemyContext enemy;
        public PlayerContext player;
    }
    
    [Serializable]
    public class PlayerContext {
        public Transform[] placements;
    }
}