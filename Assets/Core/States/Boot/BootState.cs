using Core.States.Home;
using DG_Pack.Services.FSM;
using DG_Pack.Services.Scene;
using VContainer;

namespace Core.States.Boot {
    public class BootState : IState {
        [Inject] private IStateMachine States { get; set; }
        [Inject] private ISceneService Scenes { get; set; }


        public async void Enter() {
            await Scenes.Load(SceneID.Boot);
            States.Enter<HomeState>();
        }
        public void Exit() { }
    }
}