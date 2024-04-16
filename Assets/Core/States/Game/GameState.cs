using DG_Pack.Services.FSM;
using DG_Pack.Services.Scene;
using VContainer;
// using DG.Tweening;

namespace Core.States.Game {
    public class GameState : IState {
        [Inject] private ISceneService Scene { get; set; }


        public async void Enter() {
            // DOTween.Init();
            await Scene.Load(SceneID.Game);
        }
        public void Exit() { }
    }
}