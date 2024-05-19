using System.Collections.Generic;
using Core.States.Game.Enemy;
using DG_Pack.Base.Reactive;

namespace Core.Base.Data {
    public class RuntimeData {
        public ReactiveToNew<bool> BattleMode { get; } = new();
        public ReactiveToNew<int> BattleState { get; } = new();

        public float TotalHealth { get; set; }
        public List<MonsterActor> Enemies { get; } = new();
    }
}