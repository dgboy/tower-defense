using System;
using Core.Base.Data;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.States.Game {
    public class GameStartup : IStartable, IFixedTickable, ITickable, IDisposable {
        [Inject] private IObjectResolver Resolver { get; set; }
        [Inject] private GeneralConfig Config { get; set; }
        [Inject] private LevelContext Context { get; set; }
        [Inject] private RuntimeData Data { get; set; }


        public void Start() {
            
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