using UnityEngine;

namespace Core.States.Game.Player {
    [CreateAssetMenu(menuName = "Game/Tower", fileName = "Tower")]
    public class TowerConfig : ScriptableObject {
        public TowerActor prefab;
        public TowerLevelConfig[] levels;
    }
}