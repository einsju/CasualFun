using System.Collections.Generic;
using System.Linq;
using CasualFun.AtCirclesEdge.Pooling;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

namespace CasualFun.AtCirclesEdge.Game.Levels
{
    public class WaveSpawner
    {
        readonly Spawner _spawner;

        public WaveSpawner(Spawner spawner) => _spawner = spawner;

        public List<GameObject> Spawn(Wave wave)
        {
            var spawnedPrefabs = new List<GameObject>();
            wave.Prefabs.ToList().ForEach(p => spawnedPrefabs.Add(SpawnPrefab(p)));
            return spawnedPrefabs;
        }

        GameObject SpawnPrefab(PrefabData data)
        {
            return _spawner.SpawnWithLocalPosition((int) data.Pool, data.Prefab.transform.localPosition,
                Quaternion.Euler(0, 0, data.Degrees));
        }
    }
}
