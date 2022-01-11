using System;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game.Levels
{
    [Serializable]
    public class Wave
    {
        [SerializeField] PrefabData[] prefabs;

        public PrefabData[] Prefabs => prefabs;
    }
}
