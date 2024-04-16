using System;

namespace Core.States.Game.Player {
    [Serializable]
    public class TowerLevelConfig  {
        public float cost;
        public float damage;
        public int targets = 1;
        public int range;
        public float rate;
    }
}