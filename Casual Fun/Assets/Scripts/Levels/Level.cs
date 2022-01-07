using System.Collections.Generic;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game.Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "Levels/Level", order = 1)]
    public class Level : ScriptableObject
    {
        [SerializeField] List<Wave> waves;

        public IEnumerable<Wave> Waves => waves;
    }
}
