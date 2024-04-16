using Core.States.Game;
using DG_Pack.Services.FSM;
using UnityEngine;
using VContainer;

namespace Core.States.Home {
    public class HomeScreen : MonoBehaviour {
        [Inject] private IStateMachine States { get; set; }


        public void Play() => States.Enter<GameState>();
        public void Exit() => Application.Quit();
    }
}