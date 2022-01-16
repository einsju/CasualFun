using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game.Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "Levels/Level", order = 1)]
    public class Level : ScriptableObject
    {
        [SerializeField] Wave[] spanWaves;

        public Wave[] SpanWaves => spanWaves;
    }
}
