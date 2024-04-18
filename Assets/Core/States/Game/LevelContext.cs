using Core.States.Game.Enemy;
using Core.States.Game.Player;
using DG_Pack.Base;
using UnityEngine;

namespace Core.States.Game {
    public class LevelContext : MonoBehaviour, ICoroutineRunner {
        public Transform runtimeParent;
        public EnemyContext enemy;
        public PlayerContext player;
    }
}