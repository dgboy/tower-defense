using Core.Base.Data;
using Core.States.Game.Enemy;
using Core.States.Game.Movement;
using UnityEngine;
using VContainer;

namespace Core.States.Game.Player {
    public class TowerFactory {
        [Inject] private GeneralConfig Configs { get; set; }

        private int Counter { get; set; }


        public void Create(TowerConfig config, Vector3 at, Transform parent) {
            var sample = Object.Instantiate(config.prefab, at, Quaternion.identity, parent);
            sample.name = $"{config.name} {Counter}";

            // actor.speed = config.speed;
            Counter++;
        }
    }
}