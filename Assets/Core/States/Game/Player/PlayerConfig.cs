using System;
using Core.States.Game.Common;

namespace Core.States.Game.Player {
    [Serializable]
    public class PlayerConfig {
        public int firstTower;
        public TowerConfig[] towers;
        public Projectile projectile;
    }
}