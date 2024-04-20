using Core.States.Game.Enemy;
using Core.States.Game.Player;
using DG_Pack.Base;
using UnityEngine;

namespace Core.States.Game.Common {
    public class Shooting : MonoBehaviour, ICoroutineRunner {
        public ICooldown Cooldown { get; set; }
        public TowerActor Actor { get; set; }
        public TowerProjectileFactory ProjectileFactory { get; set; }


        public void Track(Collider2D target) {
            var actor = target.GetComponent<MonsterActor>();

            if (!Cooldown.IsExpired || !actor)
                return;

            Shot(actor);
            Cooldown.Start(Actor.rate);
        }

        private void Shot(MonsterActor target) {
            ProjectileFactory.Create(Actor, target);
        }
    }
}