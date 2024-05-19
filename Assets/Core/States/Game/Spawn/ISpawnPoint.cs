using UnityEngine;

namespace Core.States.Game.Spawn {
    public interface ISpawnPoint {
        Vector3 Position { get; }
    }
}