using System;

namespace Core.States.Game.Enemy {
    [Serializable]
    public class EnemyConfig {
        public MonsterActor prefab;
        public MonsterConfig[] monsters;
        public float waveModifier = 1f;
    }
}