using Core.Base.Data;
using Core.Game.Exodus;
using DG_Pack.Services.Log;
using UnityEngine;
using VContainer;

namespace Core.States.Game.Exodus {
    public class ExodusService {
        [Inject] private ICustomLogger Logger { get; set; }
        [Inject] private GeneralConfig Configs { get; set; }
        [Inject] private LevelContext Context { get; set; }
        [Inject] private RuntimeData Data { get; set; }


        public void Declare(ExodusID id) {
            if (id == ExodusID.Victory) {
                Debug.Log($"{GetType().Name} Enemy Wave is end");
            }

            Data.BattleMode.Value = false;
            Logger.Log($"=== {id} ===", Dye.Red);
            // Data.Player = null;
            // Context.ui.Show(ViewID.DefeatModal);
        }
    }
}