using Core.Base.Data;
using Core.States.Game.Common;
using DG_Pack.Base;
using UnityEngine;
using VContainer;

namespace Core.States.Game.Player {
    public class TowerFactory {
        [Inject] private GeneralConfig Configs { get; set; }
        [Inject] private ICooldown Cooldown { get; set; }
        [Inject] private TowerProjectileFactory ProjectileFactory { get; set; }

        private int Counter { get; set; }


        public void Create(TowerConfig config, Vector3 at, Transform parent) {
            var actor = Object.Instantiate(config.prefab, at, Quaternion.identity, parent);
            actor.name = $"{config.name} {Counter}";

            var level = config.levels[0];
            actor.Radar.Range = level.range;
            actor.damage = level.damage;
            actor.rate = level.rate;

            actor.Shooting.ProjectileFactory = ProjectileFactory;
            actor.Shooting.Cooldown = Cooldown;
            actor.Shooting.Actor = actor;

            actor.Init();
            Counter++;
        }
    }
}