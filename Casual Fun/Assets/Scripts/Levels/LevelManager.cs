using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CasualFun.AtCirclesEdge.State;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game.Levels
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] Transform levelDataContainer;
        [SerializeField] List<Level> levels;

        public void PrepareLevel()
        {
            var level = levels.First();
            var firstWave = level.Waves.First();

            firstWave.Prefabs.ToList().ForEach(p =>
            {
                 StartCoroutine(CreatePrefabAfterTimeout(firstWave.Timeout, p.Prefab, p.Degrees));
            });
        }

        IEnumerator CreatePrefabAfterTimeout(float timeout, GameObject prefab, float degrees)
        {
            yield return new WaitForSeconds(timeout);
            var newPrefab = Instantiate(prefab, levelDataContainer);
            newPrefab.transform.eulerAngles = new Vector3(0, 0, degrees);
        }
    }
}
