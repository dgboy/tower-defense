using Core.States.Game.Enemy;
using Core.States.Game.Player;
using UnityEngine;

namespace Core.Base.Data {
    [CreateAssetMenu(menuName = "Base/General", fileName = "General")]
    public class GeneralConfig : ScriptableObject {
        public PlayerConfig player;
        public EnemyConfig enemy;
    }
}