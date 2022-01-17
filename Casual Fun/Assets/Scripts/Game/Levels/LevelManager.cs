using System.Collections.Generic;
using System.Linq;
using CasualFun.AtCirclesEdge.Pooling;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game.Levels
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] Level[] levels;
        [SerializeField] Spawner spawner;

        Level _currentLevel;
        LevelData _levelData;
        WaveSpawner _waveSpawner;

        void Awake() => _waveSpawner = new WaveSpawner(spawner);

        public bool IsOnLastWave => _levelData.WaveIndex == _currentLevel.SpanWaves.Length - 1;
        public bool HasFinishedAllLevels => _levelData.LevelNumber == levels.Length && IsOnLastWave;
        
        public void PrepareLevel()
        {
            _levelData = new LevelData(PlayerDataInstance.Instance.PlayerData.Level);
            _currentLevel = levels[_levelData.LevelNumber - 1];
            SpawnWave();
        }

        public void OnWaveCompleted()
        {
            _levelData.MoveToNextWave();
            SpawnWave();
        }

        void SpawnWave()
        {
            var waveToSpawn = _currentLevel.SpanWaves[_levelData.WaveIndex];
            var wavePrefabs = _waveSpawner.Spawn(waveToSpawn);
            SetWaveScorePointText(wavePrefabs);
        }

        void SetWaveScorePointText(IEnumerable<GameObject> wavePrefabs)
        {   
            var scorePoint = wavePrefabs
                .FirstOrDefault(w => w.GetComponentInChildren<ScorePoint>() != null)
                ?.GetComponentInChildren<ScorePoint>();

            if (scorePoint is null)
            {
                HandleScorePointNotSetInWave();
                return;
            }

            scorePoint.SetText($"{_currentLevel.SpanWaves.Length - _levelData.WaveIndex}");
        }

        void HandleScorePointNotSetInWave() =>
            Debug.LogWarning($"You have forgot to add score point in wave {_levelData.WaveIndex}");
    }
}
