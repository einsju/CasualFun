using System;
using System.Collections.Generic;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game.Levels
{
    [Serializable]
    public class Wave
    {
        [SerializeField] float timeout;
        [SerializeField] List<PrefabData> prefabs;

        public float Timeout => timeout;
        public IEnumerable<PrefabData> Prefabs => prefabs;
    }
}
