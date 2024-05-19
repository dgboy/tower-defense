using System.Collections.Generic;
using Core.Base.Data;
using Core.States.Game.Enemy;
using DG_Pack.UI.Canvas;
using DG_Pack.UI.Canvas.Handlers;
using UnityEngine;
using VContainer;

namespace Core.States.Game {
    public class GameHUD : MonoBehaviour {
        [Inject] private EnemyWave EnemyWave { get; set; }
        [Inject] private RuntimeData Data { get; set; }

        private List<IHandler> Handlers { get; set; }


        private void Awake() {
            Handlers = new List<IHandler> {
                new Click("StartBattleButton", EnemyWave.Start),
                new Active("StartBattleButton", Data.BattleMode, true),
                
                new ViewGroup("States", Data.BattleState),
                
                new TextVar<int>("WaveCounterLabel", EnemyWave.Counter, "Wave"),
            };

            Handlers.ForEach(x => x.Bind(this));
        }
        private void Start() {
            Handlers.ForEach(x => x.Refresh());
        }
        private void OnDestroy() {
            Handlers.ForEach(x => x.Unbind());
        }
    }
}