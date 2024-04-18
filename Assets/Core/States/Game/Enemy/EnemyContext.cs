using System;
using UnityEngine;

namespace Core.States.Game.Enemy {
    [Serializable]
    public class EnemyContext {
        public Transform[] path;
        public float totalHealth = 30;
    }
}