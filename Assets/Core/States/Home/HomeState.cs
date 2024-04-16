using DG_Pack.Services.FSM;
using DG_Pack.Services.Log;
using DG_Pack.Services.Scene;
using VContainer;

namespace Core.States.Home {
    public class HomeState : IState {
        [Inject] private ICustomLogger Logger { get; set; }
        [Inject] private ISceneService Scenes { get; set; }
        [Inject] private IStateMachine States { get; set; }


        public async void Enter() {
            await Scenes.Load(SceneID.Game);
        }
        public void Exit() { }
    }
}