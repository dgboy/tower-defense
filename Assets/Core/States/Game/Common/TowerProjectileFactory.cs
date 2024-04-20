using Core.Base.Data;
using Core.States.Game.Enemy;
using Core.States.Game.Player;
using UnityEngine;
using VContainer;

namespace Core.States.Game.Common {
    public class TowerProjectileFactory {
        [Inject] private GeneralConfig Configs { get; set; }

        public void Create(TowerActor owner, MonsterActor target) {
            // Vector3 offset = target.position;// * Config.offset;
            //, direction.ToRotation()
            var sample = Object.Instantiate(Configs.player.projectile, owner.transform.position, Quaternion.identity);

            sample.Target = target;
            sample.damage = owner.damage;
        }
    }
}