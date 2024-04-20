using System;
using Core.States.Game.Common;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.States.Game.Player {
    [Serializable]
    public class PlayerConfig {
        public TowerConfig[] towers;
        public Projectile projectile;
    }
}