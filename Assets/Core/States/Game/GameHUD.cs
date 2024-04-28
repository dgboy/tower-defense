using Core.Base.Data;
using Core.States.Game.Enemy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Core.States.Game {
    public class GameHUD : MonoBehaviour {
        [Inject] private EnemyWave EnemyWave { get; set; }
        [Inject] private RuntimeData Data { get; set; }

        public TextMeshProUGUI waveCounter;
        public Button waveStartButton;

        private void Awake() {
            EnemyWave.Counter.OnChanged += RefreshWaveCounter;
            Data.BattleMode.OnChanged += RefreshWaveStartButton;
            waveStartButton.onClick.AddListener(EnemyWave.Start);
        }
        private void Start() {
            RefreshWaveCounter();
            RefreshWaveStartButton();
        }
        private void OnDestroy() {
            EnemyWave.Counter.OnChanged -= RefreshWaveCounter;
            Data.BattleMode.OnChanged -= RefreshWaveStartButton;
            waveStartButton.onClick.RemoveListener(EnemyWave.Start);
        }


        private void RefreshWaveCounter() => waveCounter.text = $"Wave {EnemyWave.Counter.Value}";
        private void RefreshWaveStartButton() => waveStartButton.gameObject.SetActive(!Data.BattleMode.Value);
    }
}