using System;
using UnityEngine;

namespace CasualFun.AtCirclesEdge
{
    public abstract class EventManager
    {
        public static event Action ScreenOpened;
        public static void OnScreenOpened() => ScreenOpened?.Invoke();

        public static event Action<Vector3> PlayerPickedUpScorePoint;
        public static void OnPlayerPickedUpScorePoint(Vector3 position) => PlayerPickedUpScorePoint?.Invoke(position);
        
        public static event Action<Vector3> PlayerPickedUpCoin;
        public static void OnPlayerPickedUpCoin(Vector3 position) => PlayerPickedUpCoin?.Invoke(position);
        
        public static event Action<Transform> PlayerWasHitByEnemy;
        public static void OnPlayerWasHitByEnemy(Transform playerTransform) => PlayerWasHitByEnemy?.Invoke(playerTransform);
    }
}
