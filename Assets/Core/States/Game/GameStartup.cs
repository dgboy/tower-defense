using System;
using Core.Base.Data;
using Core.States.Game.Player;
using DG_Pack.Services.Log;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.States.Game {
    public class GameStartup : IStartable, IFixedTickable, ITickable, IDisposable {
        [Inject] private ICustomLogger Logger { get; set; }
        [Inject] private GeneralConfig Configs { get; set; }
        [Inject] private LevelContext Context { get; set; }
        [Inject] private RuntimeData Data { get; set; }
        [Inject] private TowerFactory TowerFactory { get; set; }


        public void Start() {
            Logger.Log("GAME START", this, Dye.Orange);
            SpawnFirstTower(Configs.player);
        }

        public void FixedTick() {
        }
        public void Tick() {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
        public void Dispose() {
        }


        private void SpawnFirstTower(PlayerConfig config) {
            TowerFactory.Create(config.towers[config.firstTower], Context.player.placements[0].position, Context.runtimeParent);
        }
    }
}