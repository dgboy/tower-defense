using System.Collections.Generic;
using Core.States.Game.Enemy;
using DG_Pack.Base.Reactive;

namespace Core.Base.Data {
    public class RuntimeData {
        public RuntimeData(GeneralConfig config) {
            // FearLevel = new ReactiveToNew<float>(config.player.fearLevel);
        }

        public ReactiveToNew<bool> BattleMode { get; } = new();
        public float TotalHealth { get; set; }
        public List<MonsterActor> Enemies { get; } = new();

    }
}