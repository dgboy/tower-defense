using UnityEngine;
using VContainer;

namespace Core.States.Game.Spawn {
    public class CertainSpawnPoint : ISpawnPoint {
        [Inject] private LevelContext Level { get; set; }

        public Vector3 Position => Level.enemy.path[0].position;
    }
}