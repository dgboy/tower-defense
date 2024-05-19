using System.Collections.Generic;
using DG_Pack.UI.Canvas;
using DG_Pack.UI.Canvas.Handlers;
using VContainer;

namespace Core.States.Game.Enemy {
    public class EnemyBase : View {
        [Inject] private EnemyWave EnemyWave { get; set; }

        protected override void Init() {
            Handlers = new List<IHandler> {
                new FloatSlider("Health", EnemyWave.Progress),
            };
        }
    }
}