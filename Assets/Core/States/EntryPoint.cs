using Core.States.Boot;
using DG_Pack.Services.FSM;
using DG_Pack.Services.Log;
using VContainer;
using VContainer.Unity;

namespace Core.States {
    public class EntryPoint : IStartable {
        [Inject] private ICustomLogger Logger { get; set; }
        [Inject] private IStateMachine States { get; set; }


        public void Start() {
            Logger.Log("START", this, Dye.Red);
            States.Enter<BootState>();
        }
    }
}