using System;
using Core.Base.Data;
using Core.States.Game.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace Core.States.Game {
    public class GameStartup : IStartable, IFixedTickable, ITickable, IDisposable {
        [Inject] private IObjectResolver Resolver { get; set; }
        [Inject] private GeneralConfig Configs { get; set; }
        [Inject] private LevelContext Context { get; set; }
        [Inject] private RuntimeData Data { get; set; }
        [Inject] private TowerFactory TowerFactory { get; set; }


        public void Start() {
            var towers = Configs.player.towers;
            TowerFactory.Create(towers[Random.Range(0, towers.Length)], Context.player.placements[0].position, Context.runtimeParent);
        }

        public void FixedTick() {
        }
        public void Tick() {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }

        public void Dispose() {
        }
    }
}