using System.Linq;
using CasualFun.AtCirclesEdge.Player;
using CasualFun.AtCirclesEdge.Pooling;
using CasualFun.AtCirclesEdge.Utilities;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game.Levels
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] Level[] levels;
        [SerializeField] Spawner spawner;

        int _levelNumber = 1;
        int _currentWaveIndex;
        Level _currentLevel;

        public bool IsOnLastWave => _currentWaveIndex == _currentLevel.SpanWaves.Length - 1;
        public bool HasFinishedAllLevels => _levelNumber >= levels.Length;
        
        string WavesRemaining => $"{_currentLevel.SpanWaves.Length - _currentWaveIndex}";
        
        public void InitializeLevel()
        {
            _levelNumber = PlayerDataManager.PlayerData.Level;
            _currentWaveIndex = 0;

            _currentLevel = levels[_levelNumber - 1];

            if (!_currentLevel.SpanWaves.Any())
            {
                Debug.Log($"You have forgotten to set up spawn waves for level {_levelNumber}");
                return;
            }

            SpawnWave();
        }

        public void SpawnNextWave()
        {
            _currentWaveIndex++;
            SpawnWave();
        }

        void SpawnWave()
        {
            var currentWave = _currentLevel.SpanWaves[_currentWaveIndex];
            currentWave.Prefabs.ToList().ForEach(SpawnWavePrefab);
        }
        
        void SpawnWavePrefab(PrefabData data)
        {
            var go = spawner.SpawnWithLocalPosition((int) data.Pool, data.Prefab.transform.localPosition, Quaternion.Euler(0, 0, data.Degrees));
            if (data.Pool != LevelPrefabPool.ScorePoint) return;
            go.GetComponentInChildren<ScorePoint>()?.SetText(WavesRemaining);
        }
    }
}
