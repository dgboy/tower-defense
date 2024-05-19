using Core.Base.Data;
using Core.States.Game.Player;
using DG_Pack.Base.Reactive;
using UnityEngine;
using VContainer;

namespace Core.States.Game.Enemy {
    public class EnemyWave {
        [Inject] private GeneralConfig Configs { get; set; }
        [Inject] private LevelContext Level { get; set; }
        [Inject] private RuntimeData Data { get; set; }
        [Inject] private PlayerBase Base { get; set; }

        public ReactiveToNew<int> Counter { get; } = new(1);
        public float MaxHeath => Counter.Value * (Level.enemy.totalHealth * Configs.enemy.waveModifier);
        public float Health { get; set; }
        public ReactiveToNew<float> Progress { get; } = new();


        public void Start() {
            Base.Restore();
            Health = MaxHeath;
            Data.BattleMode.Value = true;
            Data.BattleState.Value = 1;
            Debug.Log($"[{GetType().Name} {Counter.Value}] is starting!");
        }
    }
}